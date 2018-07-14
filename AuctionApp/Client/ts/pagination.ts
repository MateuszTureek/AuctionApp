import Observable from "./abstract/observable";
import IObserver from "./contract/iObserver";
import SelectList from "./customer/implement/filter/selectListOfAmountPages";

export default class Pagination extends Observable implements IObserver {
    private pageIndex: number = 1;
    private totalAmount: number;

    constructor(
        private $paginationUl: JQuery<HTMLElement>,
        private pageSize,
        private selectList: SelectList
    ) { super(); };

    update(): void {
        this.pageIndex = 1;
        this.pageSize = this.selectList.GetSelectedOptionValue;
    };

    events() {
        this.$paginationUl.children('li').on('click', (e: Event) => { this.pagingItemOnClick(e); });
    };

    public get PageIndex() {
        return this.pageIndex;
    };

    activePagingItem($li: JQuery<HTMLElement>) {
        $li.addClass('active');
    };

    deactivePagingItem($li: JQuery<HTMLElement>) {
        $li.remove('active');
    };

    getPagingItemByCurrentIndex() {
        const $items = this.$paginationUl.children('li'),
            length = $items.length;
        let i = 0, $li: JQuery<HTMLElement>;

        for (i; i < length; i += 1) {
            $li = $($items.get(i));
            if ($li.data('index') as number == this.pageIndex) {
                return $li;
            }
        }
    };

    getActivePagingItem() {
        const $items = this.$paginationUl.children('li'),
            length = $items.length;
        let i = 0, $li: JQuery<HTMLElement>;

        for (i; i < length; i += 1) {
            $li = $($items.get(i));
            if ($li.hasClass('active')) {
                return $li;
            }
        }
    };

    isArrow($clicked: JQuery<HTMLElement>): boolean {
        if ($clicked.data('index') === undefined) return true;
        return false;
    };

    handleArrow($li) {
        const arrow = $li.data('arrow');

        if (arrow === 'left') { this.moveLeft(); }
        if (arrow === 'right') { this.moveRight(); }
    }

    moveLeft() {
        if (this.pageIndex > 1) {
            this.pageIndex -= 1;
            const $li = this.getPagingItemByCurrentIndex();
            this.activePagingItem($li);
        }
    };

    moveRight() {
        if (this.pageIndex < Math.ceil(this.totalAmount / this.pageSize)) {
            this.pageIndex += 1;
            const $li = this.getPagingItemByCurrentIndex();
            this.activePagingItem($li);
        }
    };

    pagingItemOnClick(e: Event) {
        e.preventDefault();
        const $clickced = $(e.currentTarget);

        if (!this.isArrow($clickced)) this.pageIndex = $clickced.data('index');
        else this.handleArrow($clickced);

        this.notify();
    };

    generatePagination(totalAmount) {
        this.totalAmount = totalAmount;

        const firstArrow = this.$paginationUl.children('li').first();
        const lastArrow = this.$paginationUl.children('li').last();

        this.$paginationUl.empty();
        this.$paginationUl.append(firstArrow);
        this.$paginationUl.append(lastArrow);

        const length = Math.ceil(totalAmount / this.pageSize);
        let i = 0,
            $li;

        for (i; i < length; i += 1) {
            $li = this.getPagingItem(i + 1);
            this.addListItem($li);
        }

        const $active = this.getPagingItemByCurrentIndex();

        this.events();
        this.activePagingItem($active);
    };

    getPagingItem(index: number) {
        let $li = $('<li>'),
            $a = $('<a>');

        $a.addClass('page-link');
        $a.attr('href', '#');
        $a.text(index);

        $li.addClass('page-item');
        $li.attr('data-index', index);
        $li.append($a);

        return $li;
    };

    addListItem($li: JQuery<HTMLElement>) {
        $li.insertBefore(this.$paginationUl.children().last());
    };
};