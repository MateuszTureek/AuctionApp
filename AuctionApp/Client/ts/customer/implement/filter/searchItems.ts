import TableItems from "../table/tableItems";
import Observable from "../../../abstract/observable";

export default class Search extends Observable {
    constructor(private $searchInput: JQuery<HTMLElement>)
    {
        super();
        this.events();
    };

    get GetPhrase(): string {
        return this.$searchInput.val() as string;
    };

    protected events() {
        this.$searchInput.on('keyup', (e: Event) => { this.searchInputKeyUp(e); });
    };

    protected searchInputKeyUp(e: Event) {
        e = e as KeyboardEvent;
        this.notify();
    };
};