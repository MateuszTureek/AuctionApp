import ItemAjax from "../ajax/item/itemAjax";
import Formatter from "../formatter";
import CriteriaManager from "./implement/manager/criteriaManager";
import Search from "./implement/filter/searchItems";
import SelectList from "./implement/filter/selectListOfAmountPages";
import OrderLinksManager from "./implement/manager/orderLinksManager";
import NavTabs from "./implement/navTabs";
import TableManager from "./implement/manager/tableManager";
import CategoryAjax from "../ajax/categoryAjax";
import NewItemManager from "./implement/manager/newItemManager";

$(document).ready(() => {
    const categoryAjax = new CategoryAjax();
    const itemAjax = new ItemAjax();
    const formatter = new Formatter();

    const navTabs = new NavTabs();
    const tableManager = new TableManager(itemAjax, formatter, navTabs);

    const newItemManager = new NewItemManager(categoryAjax);
    // add observers
    navTabs.add(tableManager);
    // =========================
    $.validator.methods.range = function (value, element, param) {
        var globalizedValue = value.replace(",", ".");
        return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
    }

    $.validator.methods.number = function (value, element) {
        return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
    }
});