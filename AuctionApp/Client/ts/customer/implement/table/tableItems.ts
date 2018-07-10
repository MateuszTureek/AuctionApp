import IObserver from "../../../contract/iObserver";
import ICriteria from "../../interface/iCriteria";

export default abstract class TableItems implements IObserver {
    protected tableId;
    protected $table: JQuery<HTMLElement>;
    protected $tbody: JQuery<HTMLElement>;

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