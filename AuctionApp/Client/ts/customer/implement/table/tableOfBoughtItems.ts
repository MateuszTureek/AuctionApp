﻿import TableItems from "./tableItems";
import ItemAjax from "../../../ajax/item/itemAjax";
import Formatter from "../../../formatter";
import CriteriaManager from "../manager/criteriaManager";
import ICriteria from "../../interface/iCriteria";
import OrderLinksManager from "../manager/orderLinksManager";
import SelectList from "../filter/selectListOfAmountPages";
import Search from "../filter/searchItems";
import Pagination from "../../../pagination";

export default class TableOfBoughtItems extends TableItems {
    private containerId = 'Bought';
    private $container = $('#'+this.containerId);

    constructor(
        private itemAjax: ItemAjax,
        private formatter: Formatter
    ) {
        super();
        this.tableId = 'BoughtItemsTable';
        this.$table = $('#' + this.tableId);
        this.$tbody = this.$table.children('tbody').first();

        this.search = new Search(this.$container.find('input[type="search"]'));
        this.selectList = new SelectList(this.$container.find('select'));
        this.orderLinksManager = new OrderLinksManager(this.$table.children('thead').find('th a'));
        this.paging = new Pagination(this.$container.find('ul.pagination'), this.selectList.GetSelectedOptionValue, this.selectList);

        this.search.add(this);
        this.selectList.add(this.paging);
        this.selectList.add(this);
        this.orderLinksManager.add(this);
        this.paging.add(this);

        this.criteriaManager = new CriteriaManager(this.orderLinksManager, this.search, this.selectList, this.paging);
    };

    update(): void {
        this.renderTBody();
    };

    renderTBody() {
        const criteria = this.criteriaManager.GetCriteria;

        this.itemAjax.getBoughtItems(criteria).then((result: any) => {
            if (result.items.length !== 0) {
                const $body = this.getTBody(result.items);
                
                this.$tbody.empty();
                this.$tbody.append($body.children());
                this.paging.generatePagination(result.totalAmount);

                $('.empty').addClass('d-none');
                this.$tbody.closest('div').removeClass('d-none');
            }
            else {
                this.$tbody.empty();
                
                this.$tbody.closest('div').addClass('d-none');
                $('.empty').removeClass('d-none');
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
            $('<td>').text(item.payment),
            $('<td>').text(this.formatter.formatPrice(item.buyNowPrice)),
            $('<td>').html(this.formatter.formatDate(new Date(item.auctionStartDateMiliseconds))),
            $('<td>').html(this.formatter.formatDate(new Date(item.auctionEndDateMiliseconds))),
            $('<td>').text(this.formatter.formatPrice(item.paymentPrice)),
            $('<td>').text(this.formatter.formatPrice(item.totalCost)),
            $('<td>').append(
                $('<button>').attr('type', 'button').addClass('btn btn-info').attr('data-order-id', item.orderId).text('Szczegóły'))
        );

        return $tr;
    };
};