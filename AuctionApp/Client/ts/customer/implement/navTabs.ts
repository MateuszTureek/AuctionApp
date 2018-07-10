import Observable from "../../abstract/observable";

export default class NavTabs extends Observable {
    private $tabs: JQuery<HTMLElement>;
    private $navLinks: JQuery<HTMLElement>;

    constructor() {
        super();
        this.$tabs = $('#NavTabs');
        this.$navLinks = this.$tabs.find('a.nav-link');

        this.events();
    };

    private events() {
        this.$navLinks.on('click', (e: Event) => { this.navLinkOnClick(e); });
    };

    get GetStatus() {
        return this.$tabs.data('status');
    };

    navLinkOnClick(e: Event) {
        e.preventDefault();

        const $clickedLink = $(e.currentTarget);
        const statusVal = $clickedLink.data('status');

        this.$tabs.data('status', statusVal);
        this.notify();
    };
};