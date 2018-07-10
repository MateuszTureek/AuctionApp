import TableItems from "../table/tableItems";
import Observable from "../../../abstract/observable";

export default class OrderLinksManager extends Observable {
    private $currentLink: JQuery<HTMLElement>;

    constructor(private $links: JQuery<HTMLElement>) {
        super();
        
        this.$currentLink = this.$links.first();
        this.$links.on('click', (e: Event) => { this.linkOnClick(e); });
    };

    get GetOrderByValue(): number {
        return this.$currentLink.data('orderBy');
    };

    get GetDescValue(): boolean {
        return this.$currentLink.data('desc');
    };

    set SetDescValue(val: boolean) {
        this.$currentLink.data('desc', val);
    };
    
    linkOnClick(e: Event) {
        e.preventDefault();

        var $clicked = $(e.currentTarget);

        if ($clicked.data('orderBy') as number === this.GetOrderByValue) {
            this.SetDescValue = !this.GetDescValue;
        }
        else {
            this.SetDescValue = false;
            this.$currentLink = $clicked;
            this.SetDescValue = true;
        }
        this.notify();
    }
};