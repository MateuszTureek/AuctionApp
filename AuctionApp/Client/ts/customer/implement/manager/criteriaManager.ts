import ICriteria from "../../interface/iCriteria";
import Search from "../filter/searchItems";
import SelectList from "../filter/selectListOfAmountPages";
import Criteria from "../criteria";
import OrderLinksManager from "../manager/orderLinksManager";
import Pagination from "../../../pagination";

export default class CriteriaManager {
    criteria: Criteria;

    constructor(
        private orderLinksManager: OrderLinksManager,
        private search: Search,
        private selectList: SelectList,
        private paging: Pagination
    ) {
        this.criteria = new Criteria();
    };

    get GetCriteria(): ICriteria {
        this.criteria.OrderBy = this.orderLinksManager.GetOrderByValue;
        this.criteria.AmountOfPages = this.selectList.GetSelectedOptionValue;
        this.criteria.Phrase = this.search.GetPhrase;
        this.criteria.PageIndex = this.paging.PageIndex;
        return this.criteria;
    };
};