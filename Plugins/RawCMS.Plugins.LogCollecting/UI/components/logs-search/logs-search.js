import { RawCmsDataTableDef } from "/app/common/shared/components/data-table/data-table.js";
import { applicationsService } from "/app/modules/core/services/application.service.js";
import { fullTextService } from "/app/modules/fulltext/services/full-text.service.js";
import { evtLogSearch, evtLogFetch } from "/app/modules/logs/events.js";
import { RawCMS } from "/app/config/raw-cms.js";

const _LogsTableWrapperDef = async () => {
    const rawCmsDataTableDef = await RawCmsDataTableDef();

    return {
        data: function () {
            return {
                apiService: applicationsService,
                fullTextService: fullTextService,
                headTable: [],
                logLevel: "ALL"
            };
        },
        extends: rawCmsDataTableDef,
        methods: {
            deleteConfirmMsg(item) {
                return this.$t("core.collections.table.deleteConfirmMsgTpl");
            },
            deleteSuccessMsg(item) {
                return this.$t("core.collections.table.deleteSuccessMsgTpl");
            },
            deleteErrorMsg(item) {
                return this.$t("core.collections.table.deleteErrorMsgTpl");
            },
            showDeleteConfirm: function (item) {
                this.currentItem = item;
                this.isDeleteConfirmVisible = false;
            },
            getDataHeaders: async function () {
                this.headTable = [
                    { text: "Level", value: "Severity", sortable: false },
                    { text: "Message", value: "Message", sortable: false },
                    { text: "Date", value: "Date", sortable: false }
                ];
                return this.headTable;
            },
            showDetail() {
                this.isDetailShown = true;
            },
            fetchData: async function () {
                RawCMS.eventBus.$emit(evtLogFetch);
            },
            search: async function (query, indexname) {
                let res = await fullTextService.search(
                    {
                        size: this.pageSize,
                        start: (this.currentPage - 1) * this.pageSize,
                        searchQuery: query
                    },
                    indexname
                );

                this.items = res.map(x => {
                    return { ...x, _meta_: { isDeleting: false, isDetailShown: false } };
                });
                this.totalItemsCount = res.totalCount;
                this.isLoading = false;
            }
        }, mounted: function () {
            RawCMS.eventBus.$on(evtLogSearch, (query, indexname) => {
                this.search(query, indexname);
            });
        }
    };
};

const _LogsDetailsDef = async () => {
    const tableWrapperDef = await _LogsTableWrapperDef();
    const tpl = await RawCMS.loadComponentTpl(
        "/app/modules/logs/components/logs-search/logs-search.tpl.html"
    );

    return {
        components: {
            TableWrapper: tableWrapperDef
        },
        data: function () {
            return {
                level: 'ALL',
                levels: [
                    { level: 0, text: "ALL" },
                    { level: 1, text: "TRACE" },
                    { level: 2, text: "DEBUG" },
                    { level: 3, text: "INFO" },
                    { level: 4, text: "WARN" },
                    { level: 5, text: "ERROR" },
                    { level: 6, text: "FATAL" }
                ],
                text: '',
                indexname: '',
                isDetailShown: false,
                shownItem: {}
            };
        },
        methods: {
            search: async function () {
                RawCMS.eventBus.$emit(evtLogSearch, this.query, this.indexname);
            },
            showDetail: async function (item) {
                this.isDetailShown = true;
                this.shownItem = item;
            }
        },
        mounted: async function () {
            const res = await applicationsService.getAppByName(this.$route.params.name);
            this.indexname = "log_" + res._id;
            RawCMS.eventBus.$on(evtLogFetch, () => {
                RawCMS.eventBus.$emit(evtLogSearch, this.query, this.indexname);
            });
        },
        computed: {
            query: function () {
                let queryRegExp = /[\s|\:|\=\{|>|<|\{|\}|\"|\*|\?]/gi; //just one query character
                let query = "";

                if (this.level >= 0) {
                    query = "Severity:>=" + this.level;
                }
                if (query.length > 0 && this.text.length > 0) {
                    query += " AND ";
                }
                if (this.text.length > 0 && !queryRegExp.test(this.text)) {
                    query += " Message: ";
                }

                query += this.text;
                if (query.length == "") query = "*";

                return query;
            }
        },
        //props: detailWrapperDef.extends.props,
        props: { name: String },
        template: tpl
    };
};

const _LogsDetails = async (res, rej) => {
    const cmpDef = _LogsDetailsDef();
    res(cmpDef);
};

export const LogsDetailsDef = _LogsDetailsDef;
export const LogsDetails = _LogsDetails;
export default _LogsDetails;