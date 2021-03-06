﻿export default class MainNavLinkActivator {
    protected $linkCollection: JQuery<HTMLElement>;

    constructor(
        protected $navElem: JQuery<HTMLElement>,
        protected active: string) {

        this.init();
    };

    init() {
        this.$linkCollection = this.$navElem.children('a');
        this.setRigidlyLinksToCollection();
        this.setupLink();
    };

    setRigidlyLinksToCollection() {
        var $cartLink = $('#Cart').find('a').first();

        this.$linkCollection = this.$linkCollection.add($cartLink);
    }

    setupLink() {
        const href = window.location.pathname;
        try{
            const $link = this.getLinkByHref(href);
            this.deactiveLink();
            this.activeLink($link);
        }
        catch(e){
            console.log('Nav link for this page not exist.');
        }
    };

    getLinkByHref(href: string): JQuery<HTMLLinkElement> {
        let i = 0, $link: JQuery<HTMLLinkElement>;
        const length = this.$linkCollection.length;
        
        for (i; i < length; i += 1) {
            $link = $(this.$linkCollection.get(i)) as JQuery<HTMLLinkElement>;
            if ($link.attr('href') === href) {
                return $link;
            }
        }
        throw new Error("Not found matching nav link.");
    };

    activeLink($link: JQuery<HTMLLinkElement>) {
        $link.addClass(this.active);
    };

    deactiveLink() {
        let i = 0, $link: JQuery<HTMLLinkElement>;
        const length = this.$linkCollection.length;

        for (i; i < length; i += 1) {
            $link = $(this.$linkCollection.get(i)) as JQuery<HTMLLinkElement>;
            if ($link.hasClass(this.active)) {
                $link.remove(this.active);
            }
        }
    };
};