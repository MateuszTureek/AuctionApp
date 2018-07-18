import IObserver from "../../../contract/iObserver";
import ICriteria from "../../interface/iCriteria";
import OrderLinksManager from "../manager/orderLinksManager";
import CriteriaManager from "../manager/criteriaManager";
import SelectList from "../filter/selectListOfAmountPages";
import Search from "../filter/searchItems";
import Pagination from "../../../pagination";

export default abstract class TableItems implements IObserver {
    protected tableId;
    protected $table: JQuery<HTMLElement>;
    protected $tbody: JQuery<HTMLElement>;

    protected search: Search;
    protected selectList: SelectList;
    protected orderLinksManager: OrderLinksManager;
    protected criteriaManager: CriteriaManager;
    protected paging: Pagination;

    constructor()
    {
    };

    get GetTableId() {
        return this.tableId;
    };

    abstract renderTBody();

    abstract update();

    protected getTBody(items: any[]) {
        const length = items.length;
        let i = 0,
            $pomBody: JQuery<HTMLElement> = $('<tbody>'),
            $tr: JQuery<HTMLElement>;
        
        for (i; i < length; i += 1) {
            $tr = this.getTr(items[i]);
            $pomBody.append($tr);
        }
        return $pomBody;
    };

    protected abstract getTr(item): JQuery<HTMLElement>;
};