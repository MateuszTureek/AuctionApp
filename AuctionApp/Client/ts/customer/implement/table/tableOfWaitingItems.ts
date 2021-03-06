﻿import TableItems from "./tableItems";
import ItemAjax from "../../../ajax/item/itemAjax";
import Formatter from "../../../formatter";
import CriteriaManager from "../manager/criteriaManager";
import ICriteria from "../../interface/iCriteria";
import Search from "../filter/searchItems";
import SelectList from "../filter/selectListOfAmountPages";
import OrderLinksManager from "../manager/orderLinksManager";
import Pagination from "../../../pagination";

export default class TableOfWaitingItems extends TableItems {
    private buttonsToAuctionClass = "btn-to-auction";
    private addToAuctionConfirmId = 'BtnAddToAuctionConfirm';
    private deleteItemClass = "btn-delete-item";
    private deleteItemConfirmId = "BtnDeleteItem";
    private containerId = 'Waiting';
    private $container = $('#'+this.containerId);

    constructor(
        private itemAjax: ItemAjax,
        private formatter: Formatter
    ) {
        super();
        
        this.tableId = 'WaitingItemsTable';
        this.$table = $('#' + this.tableId);
        this.$tbody = this.$table.children('tbody').first();

        this.search = new Search(this.$container.closest('div').find('input[type="search"]'));
        this.selectList = new SelectList(this.$container.closest('div').find('select'));
        this.orderLinksManager = new OrderLinksManager(this.$table.children('thead').find('th a'));
        this.paging = new Pagination(this.$container.find('ul.pagination'), this.selectList.GetSelectedOptionValue, this.selectList);

        this.search.add(this);
        this.selectList.add(this.paging);
        this.selectList.add(this);
        this.orderLinksManager.add(this);
        this.paging.add(this);

        this.criteriaManager = new CriteriaManager(this.orderLinksManager, this.search, this.selectList, this.paging);
    };

    events() {
        const $addToAuctionBtns = $('.' + this.buttonsToAuctionClass);
        const $deleteItemBtns = $('.' + this.deleteItemClass);

        $addToAuctionBtns.on('click', (e: Event) => { this.toAuctionOnClick(e); });
        $deleteItemBtns.on('click', (e: Event) => { this.deleteItemOnClick(e); })

        const $btnDeleteConfirm = $('#' + this.deleteItemConfirmId);
        $btnDeleteConfirm.on('click', (e: Event) => { this.deleteItemConfirmOnClick(e); });

        const $btnToAuctionCofirm = $('#' + this.addToAuctionConfirmId);
        $btnToAuctionCofirm.on('click', (e: Event) => { this.toAuctionConfirmOnClick(e); });
    };

    toAuctionConfirmOnClick(e: Event) {
        const $form = $('#NewAuctionForm')
        const id = $(e.currentTarget).data('id') as number;
        let data = $form.serialize();

        data += '&ItemId=' + id;
        this.itemAjax.addItemToAuction(data).then(() => {
            window.location.href = '/customer/item';
            console.log('Item added to auction.');
        }).catch((e: Error) => { console.log(e.message); });
    };

    toAuctionOnClick(e: Event) {
        const $clicked = $(e.currentTarget);
        const id = $clicked.data('id') as number;
        const name = $clicked.data('name') as string;
        const $btnConfitm = $('#' + this.addToAuctionConfirmId);

        $('#NewAuctionModal').find('.modal-body').find('h5').find('strong').text(name);
        $btnConfitm.attr('data-id', id);
    };

    deleteItemOnClick(e: Event) {
        const $clicked = $(e.currentTarget);
        const id = $clicked.data('id') as number;
        const name = $clicked.data('name') as string;
        const $btnDelete = $('#' + this.deleteItemConfirmId);

        $('#DeleteItemModal').find('.modal-body').find('strong').text(name);
        $btnDelete.attr('data-id', id);
    };

    deleteItemConfirmOnClick(e: Event) {
        const $clicked = $(e.currentTarget);
        const id = $clicked.data('id') as number;
        const verificationToken = $('#DeleteItemModal').find('input[name="__RequestVerificationToken"]').val();

        this.itemAjax.deleteItem(id, verificationToken)
            .then(() => {
                window.location.href = '/customer/item';
                console.log('Item deleted.');
            })
            .catch((e) => { console.log('delete item error.'); });
    };

    update(): void {
        this.renderTBody();
    };

    renderTBody() {
        const criteria = this.criteriaManager.GetCriteria;

        this.itemAjax.getWaitingItems(criteria).then((result: any) => {
            if (result.items.length !== 0) {
                const $body = this.getTBody(result.items);
                
                this.$tbody.empty();
                this.$tbody.append($body.children());
                this.events();
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
            $('<td>').text(item.payment),
            $('<td>').append(
                $('<button>')
                    .attr('type', 'button')
                    .attr('data-id', item.id)
                    .attr('data-name', item.name)
                    .attr('data-toggle', 'modal')
                    .attr('data-target', '#NewAuctionModal')
                    .addClass('btn btn-success btn-sm ' + this.buttonsToAuctionClass)
                    .append($("<span>").addClass("fa fa-check"))
            ),
            $('<td>').append(
                $('<button>')
                    .attr('data-id', item.id)
                    .attr('data-name', item.name)
                    .attr('data-toggle', 'modal')
                    .attr('data-target', '#DeleteItemModal')
                    .addClass('btn btn-danger btn-sm ' + this.deleteItemClass)
                    .append($("<span>").addClass("fa fa-remove"))
            )
        );
        return $tr;
    };
};