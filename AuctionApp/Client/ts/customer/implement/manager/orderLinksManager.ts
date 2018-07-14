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

    linkOnClick(e: Event) {
        e.preventDefault();

        const $clicked = $(e.currentTarget);

        if ($clicked.data('orderBy') as number !== this.GetOrderByValue) {
            this.$currentLink.attr('href', '#');
            $clicked.removeAttr('href');

            this.$currentLink = $clicked;
        }

        this.notify();
    }
};