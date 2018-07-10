import ICriteria from "../../interface/iCriteria";
import Search from "../filter/searchItems";
import SelectList from "../filter/selectListOfAmountPages";
import Criteria from "../criteria";
import OrderLinksManager from "../manager/orderLinksManager";

export default class CriteriaManager {
    criteria: Criteria;

    constructor(
        private orderLinksManager: OrderLinksManager,
        private search: Search,
        private selectList: SelectList
    ) {
        this.criteria = new Criteria();
    };

    get GetCriteria(): ICriteria {
        this.criteria.OrderBy = this.orderLinksManager.GetOrderByValue;
        this.criteria.Desc = this.orderLinksManager.GetDescValue;
        this.criteria.AmountOfPages = this.selectList.GetSelectedOptionValue;
        this.criteria.Phrase = this.search.GetPhrase;

        return this.criteria;
    };
};