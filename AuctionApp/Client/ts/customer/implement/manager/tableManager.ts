import IObserver from "../../../contract/iObserver";
import TableFactory from "../factory/tableFactory";
import TableStartegy from "../strategy/tableStrategy";
import ItemAjax from "../../../ajax/item/itemAjax";
import Formatter from "../../../formatter";
import NavTabs from "../navTabs";
import TableItems from "../table/tableItems";
import Search from "../filter/searchItems";
import SelectList from "../filter/selectListOfAmountPages";
import OrderLinksManager from "./orderLinksManager";
import CriteriaManager from "./criteriaManager";
import OrderButtonLinkActivator from "../../../linkActivator/orderButtonLinkActivator";
import Criteria from "../criteria";

export default class TableManager implements IObserver {
    private tableFactory: TableFactory;
    private tableStrategy: TableStartegy;

    constructor(
        private itemAjax: ItemAjax,
        private formatter: Formatter,
        private navTabs: NavTabs
    ) {
        this.update();
    };

    update(): void {
        const status = this.navTabs.GetStatus;

        this.tableFactory = new TableFactory(this.itemAjax, this.formatter);
        this.tableStrategy = new TableStartegy(this.tableFactory);

        const table = this.tableStrategy.getTable(status);
        table.renderTBody();
    };
};