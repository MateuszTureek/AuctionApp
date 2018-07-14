import TableItems from "./tableItems";
import ItemAjax from "../../../ajax/item/itemAjax";
import Formatter from "../../../formatter";
import CriteriaManager from "../manager/criteriaManager";
import Search from "../filter/searchItems";
import SelectList from "../filter/selectListOfAmountPages";
import OrderLinksManager from "../manager/orderLinksManager";
import ICriteria from "../../interface/iCriteria";
import Pagination from "../../../pagination";

export default class TableOfInAuctionItems extends TableItems {
    private search: Search;
    private selectList: SelectList;
    private orderLinksManager: OrderLinksManager;
    private criteriaManager: CriteriaManager;
    private cancelAuctionButtonsClass = 'btn-cancel-auction';
    private cancenAuctionItemConfirmId = 'BtnCancelItemAuctionConfirm';
    private containerId = 'InAuction';
    private paging: Pagination;

    constructor(
        private itemAjax: ItemAjax,
        private formatter: Formatter
    ) {
        super();
        this.tableId = 'InAuctionItemsTable';
        this.$table = $('#' + this.tableId);
        this.$tbody = this.$table.children('tbody').first();
        this.search = new Search(this.$table.closest('div').find('input[type="search"]'));
        this.selectList = new SelectList(this.$table.closest('div').find('select'));
        this.orderLinksManager = new OrderLinksManager(this.$table.children('thead').find('th a'));
        this.paging = new Pagination($('#' + this.containerId).find('ul.pagination'), this.selectList.GetSelectedOptionValue, this.selectList);

        this.search.add(this);
        this.selectList.add(this.paging);
        this.selectList.add(this);
        this.orderLinksManager.add(this);
        this.paging.add(this);

        this.criteriaManager = new CriteriaManager(this.orderLinksManager, this.search, this.selectList, this.paging);
    };

    events() {
        const $cancelButtons = $('.' + this.cancelAuctionButtonsClass);
        $cancelButtons.on('click', (e: Event) => { this.btnCancelOnClick(e); });

        const $btnCancelConfirm = $('#' + this.cancenAuctionItemConfirmId);
        $btnCancelConfirm.on('click', (e: Event) => { this.btnCancelConfirmOnClick(e) });
    };

    btnCancelOnClick(e: Event) {
        const $clicked = $(e.currentTarget);
        const id = $clicked.data('id');

        $('#' + this.cancenAuctionItemConfirmId).attr('data-id', id);
    };

    btnCancelConfirmOnClick(e: Event) {
        const $btnConfirm = $(e.currentTarget);
        const id = $btnConfirm.data('id');
        const verificationToken = $('#DeleteItemModal').find('input[name="__RequestVerificationToken"]').val();

        this.itemAjax.cancelItemAuction(id, verificationToken).then(() => {
            window.location.href = '/customer/item';
            console.log('Item auction canceled');
        }).catch((e: Error) => {
            console.log('cancel item auction error');
        });
    };

    update(): void {
        this.renderTBody();
    };

    renderTBody() {
        const criteria = this.criteriaManager.GetCriteria;

        this.itemAjax.getInAuctionItems(criteria).then((result:any) => {
            if (result.items.length !== 0) {
                const $body = this.getTBody(result.items);

                this.$tbody.empty();
                this.$tbody.append($body.children());
                this.events();
                this.paging.generatePagination(result.totalAmount);
            }
            else {
                this.$tbody.empty();
            }
        }).catch((e) => { console.log('item in auction error'); });
    };

    protected getTr(item): JQuery<HTMLElement> {
        let $tr: JQuery<HTMLElement> = $('<tr>');

        $tr.append(
            $('<td>').text(item.categoryName),
            $('<td>').append(
                $('<a>')
                    .attr('href', '/item/item/' + item.id)
                    .text(item.name)
            ),
            $('<td>').text(this.formatter.formatPrice(item.buyNowPrice)),
            $('<td>').html(this.formatter.formatDate(new Date(item.auctionStartDateMiliseconds))),
            $('<td>').html(this.formatter.formatDate(new Date(item.auctionEndDateMiliseconds))),
            $('<td>').text(item.deliveryMethod),
            $('<td>').append(
                $('<a>')
                    .attr('href', '/customer/item/getItemBids/' + item.id)
                    .attr('role', 'button')
                    .addClass('btn btn-info btn-sm')
                    .text('Sprawdź')
            ),
            $('<td>').append(
                $('<button>')
                    .addClass('btn btn-warning btn-sm btn-cancel-auction')
                    .attr('data-id', item.id)
                    .attr('data-toggle', 'modal')
                    .attr('data-target', '#CancelItemAuctionModal')
                    .text('Anuluj')
            )
        );

        return $tr;
    };
}