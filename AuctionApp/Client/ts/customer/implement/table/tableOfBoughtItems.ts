import TableItems from "./tableItems";
import ItemAjax from "../../../ajax/item/itemAjax";
import Formatter from "../../../formatter";
import CriteriaManager from "../manager/criteriaManager";
import ICriteria from "../../interface/iCriteria";
import OrderLinksManager from "../manager/orderLinksManager";
import SelectList from "../filter/selectListOfAmountPages";
import Search from "../filter/searchItems";

export default class TableOfBoughtItems extends TableItems {
    private search: Search;
    private selectList: SelectList;
    private orderLinksManager: OrderLinksManager;
    private criteriaManager: CriteriaManager;

    constructor(
        private itemAjax: ItemAjax,
        private formatter: Formatter
    ) {
        super();
        this.tableId = 'BoughtItemsTable';
        this.$table = $('#' + this.tableId);
        this.$tbody = this.$table.children('tbody').first();

        this.search = new Search(this.$table.closest('div').find('input[type="search"]'));
        this.selectList = new SelectList(this.$table.closest('div').find('select'));
        this.orderLinksManager = new OrderLinksManager(this.$table.children('thead').find('th a'));

        this.search.add(this);
        this.selectList.add(this);
        this.orderLinksManager.add(this);

        this.criteriaManager = new CriteriaManager(this.orderLinksManager, this.search, this.selectList);
    };

    update(): void {
        this.renderTBody();
    };

    renderTBody() {
        const criteria = this.criteriaManager.GetCriteria;

        this.itemAjax.getBoughtItems(criteria).then((items: any[]) => {
            if (items.length !== 0) {
                const $body = this.getTBody(items);
                this.$tbody.empty();
                this.$tbody.append($body.children());
            }
            else {
                this.$tbody.empty();
            }
        }).catch((e) => { console.log('item waiting error'); });
    };

    protected getTr(item: any): JQuery<HTMLElement> {
        let $tr: JQuery<HTMLElement> = $('<tr>');

        $tr.append(
            $('<td>').text(item.categoryName),
            $('<td>').append(
                $('<a>')
                    .attr('href', '/item/item/' + item.id)
                    .text(item.name)
            ),
            $('<td>').text(item.deliveryMethod),
            $('<td>').text(this.formatter.formatPrice(item.buyNowPrice)),
            $('<td>').html(this.formatter.formatDate(new Date(item.auctionStartDateMiliseconds))),
            $('<td>').html(this.formatter.formatDate(new Date(item.auctionEndDateMiliseconds))),
            $('<td>').text(item.buyerName),
            $('<td>').text(this.formatter.formatPrice(item.buyPrice)),
            $('<td>').text(this.formatter.formatPrice(item.deliveryPrice)),
            $('<td>').text(this.formatter.formatPrice(item.totalCost))
        );

        return $tr;
    };
};