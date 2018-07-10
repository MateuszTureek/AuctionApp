import ItemAjax from "../ajax/item/itemAjax";
import Formatter from "../formatter";
import CriteriaManager from "./implement/manager/criteriaManager";
import Search from "./implement/filter/searchItems";
import SelectList from "./implement/filter/selectListOfAmountPages";
import OrderLinksManager from "./implement/manager/orderLinksManager";
import NavTabs from "./implement/navTabs";
import TableManager from "./implement/manager/tableManager";

$(document).ready(() => {

    const itemAjax = new ItemAjax();
    const formatter = new Formatter();

    const navTabs = new NavTabs();

    const tableManager = new TableManager(itemAjax, formatter, navTabs);

    navTabs.add(tableManager);
});