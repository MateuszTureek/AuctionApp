import TableItems from "../table/tableItems";
import TableStartegy from "../strategy/tableStrategy";
import Observable from "../../../abstract/observable";

export default class SelectList extends Observable {
    constructor(private $selectList: JQuery<HTMLElement>)
    {
        super();
        this.events();
    };

    events() {
        this.$selectList.on('change', (e: Event) => { this.changeListOption(e); });
    };

    get GetSelectedOptionValue(): number{
        return this.$selectList.val() as number;
    };

    changeListOption(e: Event) {
        this.notify();
    };
};