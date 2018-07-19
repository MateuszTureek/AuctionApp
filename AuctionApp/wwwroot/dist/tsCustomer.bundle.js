/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, { enumerable: true, get: getter });
/******/ 		}
/******/ 	};
/******/
/******/ 	// define __esModule on exports
/******/ 	__webpack_require__.r = function(exports) {
/******/ 		if(typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 			Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
/******/ 		}
/******/ 		Object.defineProperty(exports, '__esModule', { value: true });
/******/ 	};
/******/
/******/ 	// create a fake namespace object
/******/ 	// mode & 1: value is a module id, require it
/******/ 	// mode & 2: merge all properties of value into the ns
/******/ 	// mode & 4: return value when already ns object
/******/ 	// mode & 8|1: behave like require
/******/ 	__webpack_require__.t = function(value, mode) {
/******/ 		if(mode & 1) value = __webpack_require__(value);
/******/ 		if(mode & 8) return value;
/******/ 		if((mode & 4) && typeof value === 'object' && value && value.__esModule) return value;
/******/ 		var ns = Object.create(null);
/******/ 		__webpack_require__.r(ns);
/******/ 		Object.defineProperty(ns, 'default', { enumerable: true, value: value });
/******/ 		if(mode & 2 && typeof value != 'string') for(var key in value) __webpack_require__.d(ns, key, function(key) { return value[key]; }.bind(null, key));
/******/ 		return ns;
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";
/******/
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = "./Client/ts/customer/customer.ts");
/******/ })
/************************************************************************/
/******/ ({

/***/ "./Client/ts/abstract/observable.ts":
/*!******************************************!*\
  !*** ./Client/ts/abstract/observable.ts ***!
  \******************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return Observable; });\nclass Observable {\r\n    constructor() {\r\n        this.observers = [];\r\n    }\r\n    add(observer) {\r\n        this.observers.push(observer);\r\n    }\r\n    ;\r\n    remove(observer) {\r\n        const index = this.observers.indexOf(observer);\r\n        if (index != -1) {\r\n            this.observers.splice(index, 1);\r\n        }\r\n    }\r\n    ;\r\n    notify() {\r\n        let i = 0, length = this.observers.length;\r\n        for (i; i < length; i += 1) {\r\n            this.observers[i].update();\r\n        }\r\n    }\r\n    ;\r\n}\r\n;\r\n\n\n//# sourceURL=webpack:///./Client/ts/abstract/observable.ts?");

/***/ }),

/***/ "./Client/ts/ajax/categoryAjax.ts":
/*!****************************************!*\
  !*** ./Client/ts/ajax/categoryAjax.ts ***!
  \****************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return CategoryAjax; });\nclass CategoryAjax {\r\n    getSubcategoryByCategoryId(id) {\r\n        return $.ajax({\r\n            url: '/customer/Subcategory/SubcategoryByCatId',\r\n            type: 'GET',\r\n            data: {\r\n                id: id\r\n            }\r\n        });\r\n    }\r\n    ;\r\n}\r\n;\r\n\n\n//# sourceURL=webpack:///./Client/ts/ajax/categoryAjax.ts?");

/***/ }),

/***/ "./Client/ts/ajax/item/itemAjax.ts":
/*!*****************************************!*\
  !*** ./Client/ts/ajax/item/itemAjax.ts ***!
  \*****************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return ItemAjax; });\nclass ItemAjax {\r\n    cancelItemAuction(id, verificationTokenVal) {\r\n        return $.ajax({\r\n            url: '/customer/Item/CancelAuctionOfItem',\r\n            type: 'POST',\r\n            data: {\r\n                __RequestVerificationToken: verificationTokenVal,\r\n                id: id\r\n            }\r\n        });\r\n    }\r\n    ;\r\n    addItemToAuction(data) {\r\n        return $.ajax({\r\n            url: '/customer/Item/ItemToAuction',\r\n            type: 'POST',\r\n            data: data\r\n        });\r\n    }\r\n    ;\r\n    deleteItem(id, antiforgeryTokenVal) {\r\n        return $.ajax({\r\n            url: '/customer/Item/Delete',\r\n            type: 'POST',\r\n            data: {\r\n                __RequestVerificationToken: antiforgeryTokenVal,\r\n                id: id\r\n            }\r\n        });\r\n    }\r\n    ;\r\n    getWaitingItems(criteria) {\r\n        return $.ajax({\r\n            url: '/customer/Item/GetWaitingItems',\r\n            type: 'GET',\r\n            dataType: 'JSON',\r\n            contentType: 'application/json',\r\n            data: criteria.getCriteriaJSON()\r\n        });\r\n    }\r\n    ;\r\n    getInAuctionItems(criteria) {\r\n        return $.ajax({\r\n            url: '/customer/Item/GetInAuctionItems',\r\n            type: 'GET',\r\n            dataType: 'JSON',\r\n            contentType: 'application/json',\r\n            data: criteria.getCriteriaJSON()\r\n        });\r\n    }\r\n    ;\r\n    getBoughtItems(criteria) {\r\n        return $.ajax({\r\n            url: '/customer/Item/GetBoughtItems',\r\n            type: 'GET',\r\n            dataType: 'JSON',\r\n            contentType: 'application/json',\r\n            data: criteria.getCriteriaJSON()\r\n        });\r\n    }\r\n    ;\r\n}\r\n;\r\n\n\n//# sourceURL=webpack:///./Client/ts/ajax/item/itemAjax.ts?");

/***/ }),

/***/ "./Client/ts/customer/customer.ts":
/*!****************************************!*\
  !*** ./Client/ts/customer/customer.ts ***!
  \****************************************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony import */ var _ajax_item_itemAjax__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../ajax/item/itemAjax */ \"./Client/ts/ajax/item/itemAjax.ts\");\n/* harmony import */ var _formatter__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../formatter */ \"./Client/ts/formatter.ts\");\n/* harmony import */ var _implement_navTabs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./implement/navTabs */ \"./Client/ts/customer/implement/navTabs.ts\");\n/* harmony import */ var _implement_manager_tableManager__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./implement/manager/tableManager */ \"./Client/ts/customer/implement/manager/tableManager.ts\");\n/* harmony import */ var _ajax_categoryAjax__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../ajax/categoryAjax */ \"./Client/ts/ajax/categoryAjax.ts\");\n/* harmony import */ var _implement_manager_newItemManager__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./implement/manager/newItemManager */ \"./Client/ts/customer/implement/manager/newItemManager.ts\");\n\r\n\r\n\r\n\r\n\r\n\r\n$(document).ready(() => {\r\n    const categoryAjax = new _ajax_categoryAjax__WEBPACK_IMPORTED_MODULE_4__[\"default\"]();\r\n    const itemAjax = new _ajax_item_itemAjax__WEBPACK_IMPORTED_MODULE_0__[\"default\"]();\r\n    const formatter = new _formatter__WEBPACK_IMPORTED_MODULE_1__[\"default\"]();\r\n    const navTabs = new _implement_navTabs__WEBPACK_IMPORTED_MODULE_2__[\"default\"]();\r\n    const tableManager = new _implement_manager_tableManager__WEBPACK_IMPORTED_MODULE_3__[\"default\"](itemAjax, formatter, navTabs);\r\n    const newItemManager = new _implement_manager_newItemManager__WEBPACK_IMPORTED_MODULE_5__[\"default\"](categoryAjax);\r\n    // add observers\r\n    navTabs.add(tableManager);\r\n    // =========================\r\n    $.validator.methods.range = function (value, element, param) {\r\n        var globalizedValue = value.replace(\",\", \".\");\r\n        return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);\r\n    };\r\n    $.validator.methods.number = function (value, element) {\r\n        return this.optional(element) || /^-?(?:\\d+|\\d{1,3}(?:[\\s\\.,]\\d{3})+)(?:[\\.,]\\d+)?$/.test(value);\r\n    };\r\n});\r\n\n\n//# sourceURL=webpack:///./Client/ts/customer/customer.ts?");

/***/ }),

/***/ "./Client/ts/customer/implement/criteria.ts":
/*!**************************************************!*\
  !*** ./Client/ts/customer/implement/criteria.ts ***!
  \**************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return Criteria; });\nclass Criteria {\r\n    getCriteriaJSON() {\r\n        return {\r\n            orderBy: this.OrderBy,\r\n            phrase: this.Phrase,\r\n            amountOfPages: this.AmountOfPages,\r\n            pageIndex: this.PageIndex\r\n        };\r\n    }\r\n    ;\r\n}\r\n;\r\n\n\n//# sourceURL=webpack:///./Client/ts/customer/implement/criteria.ts?");

/***/ }),

/***/ "./Client/ts/customer/implement/factory/tableFactory.ts":
/*!**************************************************************!*\
  !*** ./Client/ts/customer/implement/factory/tableFactory.ts ***!
  \**************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return TableFactory; });\n/* harmony import */ var _table_TableOfWaitingItems__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../table/TableOfWaitingItems */ \"./Client/ts/customer/implement/table/TableOfWaitingItems.ts\");\n/* harmony import */ var _table_tableOfInAuctionItems__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../table/tableOfInAuctionItems */ \"./Client/ts/customer/implement/table/tableOfInAuctionItems.ts\");\n/* harmony import */ var _table_tableOfBoughtItems__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../table/tableOfBoughtItems */ \"./Client/ts/customer/implement/table/tableOfBoughtItems.ts\");\n\r\n\r\n\r\nclass TableFactory {\r\n    constructor(itemAjax, formatter) {\r\n        this.itemAjax = itemAjax;\r\n        this.formatter = formatter;\r\n    }\r\n    ;\r\n    createWaitingItemsTable() {\r\n        return new _table_TableOfWaitingItems__WEBPACK_IMPORTED_MODULE_0__[\"default\"](this.itemAjax, this.formatter);\r\n    }\r\n    ;\r\n    createInAuctionItemsTable() {\r\n        return new _table_tableOfInAuctionItems__WEBPACK_IMPORTED_MODULE_1__[\"default\"](this.itemAjax, this.formatter);\r\n    }\r\n    ;\r\n    createBoughtItemsTable() {\r\n        return new _table_tableOfBoughtItems__WEBPACK_IMPORTED_MODULE_2__[\"default\"](this.itemAjax, this.formatter);\r\n    }\r\n    ;\r\n}\r\n;\r\n\n\n//# sourceURL=webpack:///./Client/ts/customer/implement/factory/tableFactory.ts?");

/***/ }),

/***/ "./Client/ts/customer/implement/filter/searchItems.ts":
/*!************************************************************!*\
  !*** ./Client/ts/customer/implement/filter/searchItems.ts ***!
  \************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return Search; });\n/* harmony import */ var _abstract_observable__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../../../abstract/observable */ \"./Client/ts/abstract/observable.ts\");\n\r\nclass Search extends _abstract_observable__WEBPACK_IMPORTED_MODULE_0__[\"default\"] {\r\n    constructor($searchInput) {\r\n        super();\r\n        this.$searchInput = $searchInput;\r\n        this.events();\r\n    }\r\n    ;\r\n    get GetPhrase() {\r\n        return this.$searchInput.val();\r\n    }\r\n    ;\r\n    events() {\r\n        this.$searchInput.on('keyup', (e) => { this.searchInputKeyUp(e); });\r\n    }\r\n    ;\r\n    searchInputKeyUp(e) {\r\n        e = e;\r\n        this.notify();\r\n    }\r\n    ;\r\n}\r\n;\r\n\n\n//# sourceURL=webpack:///./Client/ts/customer/implement/filter/searchItems.ts?");

/***/ }),

/***/ "./Client/ts/customer/implement/filter/selectListOfAmountPages.ts":
/*!************************************************************************!*\
  !*** ./Client/ts/customer/implement/filter/selectListOfAmountPages.ts ***!
  \************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return SelectList; });\n/* harmony import */ var _abstract_observable__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../../../abstract/observable */ \"./Client/ts/abstract/observable.ts\");\n\r\nclass SelectList extends _abstract_observable__WEBPACK_IMPORTED_MODULE_0__[\"default\"] {\r\n    constructor($selectList) {\r\n        super();\r\n        this.$selectList = $selectList;\r\n        this.events();\r\n    }\r\n    ;\r\n    events() {\r\n        this.$selectList.on('change', (e) => { this.changeListOption(e); });\r\n    }\r\n    ;\r\n    get GetSelectedOptionValue() {\r\n        return this.$selectList.val();\r\n    }\r\n    ;\r\n    changeListOption(e) {\r\n        this.notify();\r\n    }\r\n    ;\r\n}\r\n;\r\n\n\n//# sourceURL=webpack:///./Client/ts/customer/implement/filter/selectListOfAmountPages.ts?");

/***/ }),

/***/ "./Client/ts/customer/implement/manager/criteriaManager.ts":
/*!*****************************************************************!*\
  !*** ./Client/ts/customer/implement/manager/criteriaManager.ts ***!
  \*****************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return CriteriaManager; });\n/* harmony import */ var _criteria__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../criteria */ \"./Client/ts/customer/implement/criteria.ts\");\n\r\nclass CriteriaManager {\r\n    constructor(orderLinksManager, search, selectList, paging) {\r\n        this.orderLinksManager = orderLinksManager;\r\n        this.search = search;\r\n        this.selectList = selectList;\r\n        this.paging = paging;\r\n        this.criteria = new _criteria__WEBPACK_IMPORTED_MODULE_0__[\"default\"]();\r\n    }\r\n    ;\r\n    get GetCriteria() {\r\n        this.criteria.OrderBy = this.orderLinksManager.GetOrderByValue;\r\n        this.criteria.AmountOfPages = this.selectList.GetSelectedOptionValue;\r\n        this.criteria.Phrase = this.search.GetPhrase;\r\n        this.criteria.PageIndex = this.paging.PageIndex;\r\n        return this.criteria;\r\n    }\r\n    ;\r\n}\r\n;\r\n\n\n//# sourceURL=webpack:///./Client/ts/customer/implement/manager/criteriaManager.ts?");

/***/ }),

/***/ "./Client/ts/customer/implement/manager/newItemManager.ts":
/*!****************************************************************!*\
  !*** ./Client/ts/customer/implement/manager/newItemManager.ts ***!
  \****************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return NewItemManager; });\nclass NewItemManager {\r\n    constructor(categoryAjax) {\r\n        this.categoryAjax = categoryAjax;\r\n        this.$categorySelectList = $('#CatId');\r\n        this.$subcategorySelectList = $('#SubcatId');\r\n        this.$btnNewDescription = $('#BtnNewItemDescription');\r\n        this.$btnDeleteDescription = $('#BtnDeleteItemDescription');\r\n        this.$descriptionsContainer = $('#ItemDescriptions');\r\n        this.events();\r\n    }\r\n    ;\r\n    events() {\r\n        this.$categorySelectList.on('change', () => { this.categorySelectListOnChange(); });\r\n        this.$btnNewDescription.on('click', () => { this.btnNewDescriptionOnClick(); });\r\n        this.$btnDeleteDescription.on('click', () => { this.btnDeleteDescriptionOnClick(); });\r\n    }\r\n    ;\r\n    btnNewDescriptionOnClick() {\r\n        this.generateDescriptionFields();\r\n    }\r\n    ;\r\n    btnDeleteDescriptionOnClick() {\r\n        this.removeDescriptionFilds();\r\n    }\r\n    ;\r\n    removeDescriptionFilds() {\r\n        const $descriptions = this.$descriptionsContainer.children('div.item-description-wrapper');\r\n        const length = $descriptions.length;\r\n        if (length > 0) {\r\n            $descriptions.last().remove();\r\n        }\r\n    }\r\n    ;\r\n    generateDescriptionFields() {\r\n        const $descriptions = this.$descriptionsContainer.children('div.item-description-wrapper');\r\n        const length = $descriptions.length;\r\n        const containerStyles = 'item-description-wrapper col-lg-12 mb-1';\r\n        let $container = $('<div>').addClass(containerStyles);\r\n        let $titleRow = $('<div>').addClass('row mb-1');\r\n        let $contentRow = $('<div>').addClass('row');\r\n        let $lblTitle = $('<label>').addClass('col-lg-3').text('Tytuł:');\r\n        let $lblContent = $('<label>').addClass('col-lg-3').text('Opis:');\r\n        let $txtTitleWrpper = $('<div>').addClass('col-lg-9');\r\n        let $txtAreaContentWrapper = $('<div>').addClass('col-lg-9');\r\n        let $txtTitle = $('<input>')\r\n            .addClass('form-control')\r\n            .attr('type', 'text')\r\n            .attr('name', 'Descriptions[' + length + '].Key')\r\n            .attr('required', 'true')\r\n            .attr('maxlength', 80);\r\n        let $txtAreaContent = $('<textarea>')\r\n            .addClass('form-control')\r\n            .attr('required', 'true')\r\n            .attr('name', 'Descriptions[' + length + '].Value');\r\n        $txtTitleWrpper.append($txtTitle);\r\n        $titleRow.append($lblTitle);\r\n        $titleRow.append($txtTitleWrpper);\r\n        $txtAreaContentWrapper.append($txtAreaContent);\r\n        $contentRow.append($lblContent);\r\n        $contentRow.append($txtAreaContentWrapper);\r\n        $container.append($titleRow);\r\n        $container.append($contentRow);\r\n        this.$descriptionsContainer.append($container);\r\n    }\r\n    ;\r\n    categorySelectListOnChange() {\r\n        const value = this.$categorySelectList.val();\r\n        this.categoryAjax.getSubcategoryByCategoryId(value).then((selectListItemArray) => {\r\n            this.$subcategorySelectList.empty();\r\n            this.generateOptionToSelectList(this.$subcategorySelectList, selectListItemArray);\r\n        }).catch((e) => { console.log('error'); });\r\n    }\r\n    ;\r\n    generateOptionToSelectList(selectList, items) {\r\n        const length = items.length;\r\n        let i = 0, $option;\r\n        for (i; i < length; i += 1) {\r\n            $option = $('<option>');\r\n            $option.text(items[i].text);\r\n            $option.val(items[i].value);\r\n            selectList.append($option);\r\n        }\r\n    }\r\n    ;\r\n}\r\n;\r\n\n\n//# sourceURL=webpack:///./Client/ts/customer/implement/manager/newItemManager.ts?");

/***/ }),

/***/ "./Client/ts/customer/implement/manager/orderLinksManager.ts":
/*!*******************************************************************!*\
  !*** ./Client/ts/customer/implement/manager/orderLinksManager.ts ***!
  \*******************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return OrderLinksManager; });\n/* harmony import */ var _abstract_observable__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../../../abstract/observable */ \"./Client/ts/abstract/observable.ts\");\n\r\nclass OrderLinksManager extends _abstract_observable__WEBPACK_IMPORTED_MODULE_0__[\"default\"] {\r\n    constructor($links) {\r\n        super();\r\n        this.$links = $links;\r\n        this.$currentLink = this.$links.first();\r\n        this.$links.on('click', (e) => { this.linkOnClick(e); });\r\n    }\r\n    ;\r\n    get GetOrderByValue() {\r\n        return this.$currentLink.data('orderBy');\r\n    }\r\n    ;\r\n    linkOnClick(e) {\r\n        e.preventDefault();\r\n        const $clicked = $(e.currentTarget);\r\n        if ($clicked.data('orderBy') !== this.GetOrderByValue) {\r\n            this.$currentLink.attr('href', '#');\r\n            $clicked.removeAttr('href');\r\n            this.$currentLink = $clicked;\r\n        }\r\n        this.notify();\r\n    }\r\n}\r\n;\r\n\n\n//# sourceURL=webpack:///./Client/ts/customer/implement/manager/orderLinksManager.ts?");

/***/ }),

/***/ "./Client/ts/customer/implement/manager/tableManager.ts":
/*!**************************************************************!*\
  !*** ./Client/ts/customer/implement/manager/tableManager.ts ***!
  \**************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return TableManager; });\n/* harmony import */ var _factory_tableFactory__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../factory/tableFactory */ \"./Client/ts/customer/implement/factory/tableFactory.ts\");\n/* harmony import */ var _strategy_tableStrategy__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../strategy/tableStrategy */ \"./Client/ts/customer/implement/strategy/tableStrategy.ts\");\n\r\n\r\nclass TableManager {\r\n    constructor(itemAjax, formatter, navTabs) {\r\n        this.itemAjax = itemAjax;\r\n        this.formatter = formatter;\r\n        this.navTabs = navTabs;\r\n        this.update();\r\n    }\r\n    ;\r\n    update() {\r\n        const status = this.navTabs.GetStatus;\r\n        this.tableFactory = new _factory_tableFactory__WEBPACK_IMPORTED_MODULE_0__[\"default\"](this.itemAjax, this.formatter);\r\n        this.tableStrategy = new _strategy_tableStrategy__WEBPACK_IMPORTED_MODULE_1__[\"default\"](this.tableFactory);\r\n        const table = this.tableStrategy.getTable(status);\r\n        table.renderTBody();\r\n    }\r\n    ;\r\n}\r\n;\r\n\n\n//# sourceURL=webpack:///./Client/ts/customer/implement/manager/tableManager.ts?");

/***/ }),

/***/ "./Client/ts/customer/implement/navTabs.ts":
/*!*************************************************!*\
  !*** ./Client/ts/customer/implement/navTabs.ts ***!
  \*************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return NavTabs; });\n/* harmony import */ var _abstract_observable__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../../abstract/observable */ \"./Client/ts/abstract/observable.ts\");\n\r\nclass NavTabs extends _abstract_observable__WEBPACK_IMPORTED_MODULE_0__[\"default\"] {\r\n    constructor() {\r\n        super();\r\n        this.$tabs = $('#NavTabs');\r\n        this.$navLinks = this.$tabs.find('a.nav-link');\r\n        this.events();\r\n    }\r\n    ;\r\n    events() {\r\n        this.$navLinks.on('click', (e) => { this.navLinkOnClick(e); });\r\n    }\r\n    ;\r\n    get GetStatus() {\r\n        return this.$tabs.data('status');\r\n    }\r\n    ;\r\n    navLinkOnClick(e) {\r\n        e.preventDefault();\r\n        const $clickedLink = $(e.currentTarget);\r\n        const statusVal = $clickedLink.data('status');\r\n        this.$tabs.data('status', statusVal);\r\n        this.notify();\r\n    }\r\n    ;\r\n}\r\n;\r\n\n\n//# sourceURL=webpack:///./Client/ts/customer/implement/navTabs.ts?");

/***/ }),

/***/ "./Client/ts/customer/implement/strategy/tableStrategy.ts":
/*!****************************************************************!*\
  !*** ./Client/ts/customer/implement/strategy/tableStrategy.ts ***!
  \****************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return TableStartegy; });\n/* harmony import */ var _enum_status__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../../../enum/status */ \"./Client/ts/enum/status.ts\");\n\r\nclass TableStartegy {\r\n    constructor(tableFactory) {\r\n        this.tableFactory = tableFactory;\r\n    }\r\n    ;\r\n    getTable(status) {\r\n        let table;\r\n        switch (status) {\r\n            case _enum_status__WEBPACK_IMPORTED_MODULE_0__[\"Status\"].InAuction: {\r\n                return this.tableFactory.createInAuctionItemsTable();\r\n            }\r\n            case _enum_status__WEBPACK_IMPORTED_MODULE_0__[\"Status\"].Bought: {\r\n                return this.tableFactory.createBoughtItemsTable();\r\n            }\r\n            default: {\r\n                return this.tableFactory.createWaitingItemsTable();\r\n            }\r\n        }\r\n        ;\r\n    }\r\n    ;\r\n}\r\n;\r\n\n\n//# sourceURL=webpack:///./Client/ts/customer/implement/strategy/tableStrategy.ts?");

/***/ }),

/***/ "./Client/ts/customer/implement/table/TableOfWaitingItems.ts":
/*!*******************************************************************!*\
  !*** ./Client/ts/customer/implement/table/TableOfWaitingItems.ts ***!
  \*******************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return TableOfWaitingItems; });\n/* harmony import */ var _tableItems__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./tableItems */ \"./Client/ts/customer/implement/table/tableItems.ts\");\n/* harmony import */ var _manager_criteriaManager__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../manager/criteriaManager */ \"./Client/ts/customer/implement/manager/criteriaManager.ts\");\n/* harmony import */ var _filter_searchItems__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../filter/searchItems */ \"./Client/ts/customer/implement/filter/searchItems.ts\");\n/* harmony import */ var _filter_selectListOfAmountPages__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../filter/selectListOfAmountPages */ \"./Client/ts/customer/implement/filter/selectListOfAmountPages.ts\");\n/* harmony import */ var _manager_orderLinksManager__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../manager/orderLinksManager */ \"./Client/ts/customer/implement/manager/orderLinksManager.ts\");\n/* harmony import */ var _pagination__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../../pagination */ \"./Client/ts/pagination.ts\");\n\r\n\r\n\r\n\r\n\r\n\r\nclass TableOfWaitingItems extends _tableItems__WEBPACK_IMPORTED_MODULE_0__[\"default\"] {\r\n    constructor(itemAjax, formatter) {\r\n        super();\r\n        this.itemAjax = itemAjax;\r\n        this.formatter = formatter;\r\n        this.buttonsToAuctionClass = \"btn-to-auction\";\r\n        this.addToAuctionConfirmId = 'BtnAddToAuctionConfirm';\r\n        this.deleteItemClass = \"btn-delete-item\";\r\n        this.deleteItemConfirmId = \"BtnDeleteItem\";\r\n        this.containerId = 'Waiting';\r\n        this.tableId = 'WaitingItemsTable';\r\n        this.$table = $('#' + this.tableId);\r\n        this.$tbody = this.$table.children('tbody').first();\r\n        this.search = new _filter_searchItems__WEBPACK_IMPORTED_MODULE_2__[\"default\"](this.$table.closest('div').find('input[type=\"search\"]'));\r\n        this.selectList = new _filter_selectListOfAmountPages__WEBPACK_IMPORTED_MODULE_3__[\"default\"](this.$table.closest('div').find('select'));\r\n        this.orderLinksManager = new _manager_orderLinksManager__WEBPACK_IMPORTED_MODULE_4__[\"default\"](this.$table.children('thead').find('th a'));\r\n        this.paging = new _pagination__WEBPACK_IMPORTED_MODULE_5__[\"default\"]($('#' + this.containerId).find('ul.pagination'), this.selectList.GetSelectedOptionValue, this.selectList);\r\n        this.search.add(this);\r\n        this.selectList.add(this.paging);\r\n        this.selectList.add(this);\r\n        this.orderLinksManager.add(this);\r\n        this.paging.add(this);\r\n        this.criteriaManager = new _manager_criteriaManager__WEBPACK_IMPORTED_MODULE_1__[\"default\"](this.orderLinksManager, this.search, this.selectList, this.paging);\r\n    }\r\n    ;\r\n    events() {\r\n        const $addToAuctionBtns = $('.' + this.buttonsToAuctionClass);\r\n        const $deleteItemBtns = $('.' + this.deleteItemClass);\r\n        $addToAuctionBtns.on('click', (e) => { this.toAuctionOnClick(e); });\r\n        $deleteItemBtns.on('click', (e) => { this.deleteItemOnClick(e); });\r\n        const $btnDeleteConfirm = $('#' + this.deleteItemConfirmId);\r\n        $btnDeleteConfirm.on('click', (e) => { this.deleteItemConfirmOnClick(e); });\r\n        const $btnToAuctionCofirm = $('#' + this.addToAuctionConfirmId);\r\n        $btnToAuctionCofirm.on('click', (e) => { this.toAuctionConfirmOnClick(e); });\r\n    }\r\n    ;\r\n    toAuctionConfirmOnClick(e) {\r\n        const $form = $('#NewAuctionForm');\r\n        const id = $(e.currentTarget).data('id');\r\n        let data = $form.serialize();\r\n        data += '&ItemId=' + id;\r\n        this.itemAjax.addItemToAuction(data).then(() => {\r\n            window.location.href = '/customer/item';\r\n            console.log('Item added to auction.');\r\n        }).catch((e) => { console.log(e.message); });\r\n    }\r\n    ;\r\n    toAuctionOnClick(e) {\r\n        const $clicked = $(e.currentTarget);\r\n        const id = $clicked.data('id');\r\n        const name = $clicked.data('name');\r\n        const $btnConfitm = $('#' + this.addToAuctionConfirmId);\r\n        $('#NewAuctionModal').find('.modal-body').find('h5').find('strong').text(name);\r\n        $btnConfitm.attr('data-id', id);\r\n    }\r\n    ;\r\n    deleteItemOnClick(e) {\r\n        const $clicked = $(e.currentTarget);\r\n        const id = $clicked.data('id');\r\n        const name = $clicked.data('name');\r\n        const $btnDelete = $('#' + this.deleteItemConfirmId);\r\n        $('#DeleteItemModal').find('.modal-body').find('strong').text(name);\r\n        $btnDelete.attr('data-id', id);\r\n    }\r\n    ;\r\n    deleteItemConfirmOnClick(e) {\r\n        const $clicked = $(e.currentTarget);\r\n        const id = $clicked.data('id');\r\n        const verificationToken = $('#DeleteItemModal').find('input[name=\"__RequestVerificationToken\"]').val();\r\n        this.itemAjax.deleteItem(id, verificationToken)\r\n            .then(() => {\r\n            window.location.href = '/customer/item';\r\n            console.log('Item deleted.');\r\n        })\r\n            .catch((e) => { console.log('delete item error.'); });\r\n    }\r\n    ;\r\n    update() {\r\n        this.renderTBody();\r\n    }\r\n    ;\r\n    renderTBody() {\r\n        const criteria = this.criteriaManager.GetCriteria;\r\n        this.itemAjax.getWaitingItems(criteria).then((result) => {\r\n            if (result.items.length !== 0) {\r\n                const $body = this.getTBody(result.items);\r\n                this.$tbody.empty();\r\n                this.$tbody.append($body.children());\r\n                this.events();\r\n                this.paging.generatePagination(result.totalAmount);\r\n            }\r\n            else {\r\n                this.$tbody.empty();\r\n            }\r\n        }).catch((e) => { console.log('item waiting error'); });\r\n    }\r\n    ;\r\n    getTr(item) {\r\n        let $tr = $('<tr>');\r\n        $tr.append($('<td>').text(item.categoryName), $('<td>').append($('<a>')\r\n            .attr('href', '/item/item/' + item.id)\r\n            .text(item.name)), $('<td>').text(this.formatter.formatPrice(item.buyNowPrice)), $('<td>').text(item.deliveryMethod), $('<td>').append($('<button>')\r\n            .attr('type', 'button')\r\n            .attr('data-id', item.id)\r\n            .attr('data-name', item.name)\r\n            .attr('data-toggle', 'modal')\r\n            .attr('data-target', '#NewAuctionModal')\r\n            .addClass('btn btn-success btn-sm ' + this.buttonsToAuctionClass)\r\n            .append($(\"<span>\").addClass(\"fa fa-check\"))), $('<td>').append($('<button>')\r\n            .attr('data-id', item.id)\r\n            .attr('data-name', item.name)\r\n            .attr('data-toggle', 'modal')\r\n            .attr('data-target', '#DeleteItemModal')\r\n            .addClass('btn btn-danger btn-sm ' + this.deleteItemClass)\r\n            .append($(\"<span>\").addClass(\"fa fa-remove\"))));\r\n        return $tr;\r\n    }\r\n    ;\r\n}\r\n;\r\n\n\n//# sourceURL=webpack:///./Client/ts/customer/implement/table/TableOfWaitingItems.ts?");

/***/ }),

/***/ "./Client/ts/customer/implement/table/tableItems.ts":
/*!**********************************************************!*\
  !*** ./Client/ts/customer/implement/table/tableItems.ts ***!
  \**********************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return TableItems; });\nclass TableItems {\r\n    constructor() {\r\n    }\r\n    ;\r\n    get GetTableId() {\r\n        return this.tableId;\r\n    }\r\n    ;\r\n    getTBody(items) {\r\n        const length = items.length;\r\n        let i = 0, $pomBody = $('<tbody>'), $tr;\r\n        for (i; i < length; i += 1) {\r\n            $tr = this.getTr(items[i]);\r\n            $pomBody.append($tr);\r\n        }\r\n        return $pomBody;\r\n    }\r\n    ;\r\n}\r\n;\r\n\n\n//# sourceURL=webpack:///./Client/ts/customer/implement/table/tableItems.ts?");

/***/ }),

/***/ "./Client/ts/customer/implement/table/tableOfBoughtItems.ts":
/*!******************************************************************!*\
  !*** ./Client/ts/customer/implement/table/tableOfBoughtItems.ts ***!
  \******************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return TableOfBoughtItems; });\n/* harmony import */ var _tableItems__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./tableItems */ \"./Client/ts/customer/implement/table/tableItems.ts\");\n/* harmony import */ var _manager_criteriaManager__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../manager/criteriaManager */ \"./Client/ts/customer/implement/manager/criteriaManager.ts\");\n/* harmony import */ var _manager_orderLinksManager__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../manager/orderLinksManager */ \"./Client/ts/customer/implement/manager/orderLinksManager.ts\");\n/* harmony import */ var _filter_selectListOfAmountPages__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../filter/selectListOfAmountPages */ \"./Client/ts/customer/implement/filter/selectListOfAmountPages.ts\");\n/* harmony import */ var _filter_searchItems__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../filter/searchItems */ \"./Client/ts/customer/implement/filter/searchItems.ts\");\n/* harmony import */ var _pagination__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../../pagination */ \"./Client/ts/pagination.ts\");\n\r\n\r\n\r\n\r\n\r\n\r\nclass TableOfBoughtItems extends _tableItems__WEBPACK_IMPORTED_MODULE_0__[\"default\"] {\r\n    constructor(itemAjax, formatter) {\r\n        super();\r\n        this.itemAjax = itemAjax;\r\n        this.formatter = formatter;\r\n        this.containerId = 'Bought';\r\n        this.tableId = 'BoughtItemsTable';\r\n        this.$table = $('#' + this.tableId);\r\n        this.$tbody = this.$table.children('tbody').first();\r\n        this.search = new _filter_searchItems__WEBPACK_IMPORTED_MODULE_4__[\"default\"](this.$table.closest('div').find('input[type=\"search\"]'));\r\n        this.selectList = new _filter_selectListOfAmountPages__WEBPACK_IMPORTED_MODULE_3__[\"default\"](this.$table.closest('div').find('select'));\r\n        this.orderLinksManager = new _manager_orderLinksManager__WEBPACK_IMPORTED_MODULE_2__[\"default\"](this.$table.children('thead').find('th a'));\r\n        this.paging = new _pagination__WEBPACK_IMPORTED_MODULE_5__[\"default\"]($('#' + this.containerId).find('ul.pagination'), this.selectList.GetSelectedOptionValue, this.selectList);\r\n        this.search.add(this);\r\n        this.selectList.add(this.paging);\r\n        this.selectList.add(this);\r\n        this.orderLinksManager.add(this);\r\n        this.paging.add(this);\r\n        this.criteriaManager = new _manager_criteriaManager__WEBPACK_IMPORTED_MODULE_1__[\"default\"](this.orderLinksManager, this.search, this.selectList, this.paging);\r\n    }\r\n    ;\r\n    update() {\r\n        this.renderTBody();\r\n    }\r\n    ;\r\n    renderTBody() {\r\n        const criteria = this.criteriaManager.GetCriteria;\r\n        this.itemAjax.getBoughtItems(criteria).then((result) => {\r\n            if (result.items.length !== 0) {\r\n                const $body = this.getTBody(result.items);\r\n                this.$tbody.empty();\r\n                this.$tbody.append($body.children());\r\n                this.paging.generatePagination(result.totalAmount);\r\n            }\r\n            else {\r\n                this.$tbody.empty();\r\n            }\r\n        }).catch((e) => { console.log('item waiting error'); });\r\n    }\r\n    ;\r\n    getTr(item) {\r\n        let $tr = $('<tr>');\r\n        $tr.append($('<td>').text(item.categoryName), $('<td>').append($('<a>')\r\n            .attr('href', '/item/item/' + item.id)\r\n            .text(item.name)), $('<td>').text(item.deliveryMethod), $('<td>').text(this.formatter.formatPrice(item.buyNowPrice)), $('<td>').html(this.formatter.formatDate(new Date(item.auctionStartDateMiliseconds))), $('<td>').html(this.formatter.formatDate(new Date(item.auctionEndDateMiliseconds))), $('<td>').text(item.buyerName), $('<td>').text(this.formatter.formatPrice(item.buyPrice)), $('<td>').text(this.formatter.formatPrice(item.deliveryPrice)), $('<td>').text(this.formatter.formatPrice(item.totalCost)));\r\n        return $tr;\r\n    }\r\n    ;\r\n}\r\n;\r\n\n\n//# sourceURL=webpack:///./Client/ts/customer/implement/table/tableOfBoughtItems.ts?");

/***/ }),

/***/ "./Client/ts/customer/implement/table/tableOfInAuctionItems.ts":
/*!*********************************************************************!*\
  !*** ./Client/ts/customer/implement/table/tableOfInAuctionItems.ts ***!
  \*********************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return TableOfInAuctionItems; });\n/* harmony import */ var _tableItems__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./tableItems */ \"./Client/ts/customer/implement/table/tableItems.ts\");\n/* harmony import */ var _manager_criteriaManager__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../manager/criteriaManager */ \"./Client/ts/customer/implement/manager/criteriaManager.ts\");\n/* harmony import */ var _filter_searchItems__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../filter/searchItems */ \"./Client/ts/customer/implement/filter/searchItems.ts\");\n/* harmony import */ var _filter_selectListOfAmountPages__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../filter/selectListOfAmountPages */ \"./Client/ts/customer/implement/filter/selectListOfAmountPages.ts\");\n/* harmony import */ var _manager_orderLinksManager__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../manager/orderLinksManager */ \"./Client/ts/customer/implement/manager/orderLinksManager.ts\");\n/* harmony import */ var _pagination__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../../pagination */ \"./Client/ts/pagination.ts\");\n\r\n\r\n\r\n\r\n\r\n\r\nclass TableOfInAuctionItems extends _tableItems__WEBPACK_IMPORTED_MODULE_0__[\"default\"] {\r\n    constructor(itemAjax, formatter) {\r\n        super();\r\n        this.itemAjax = itemAjax;\r\n        this.formatter = formatter;\r\n        this.cancelAuctionButtonsClass = 'btn-cancel-auction';\r\n        this.cancenAuctionItemConfirmId = 'BtnCancelItemAuctionConfirm';\r\n        this.containerId = 'InAuction';\r\n        this.tableId = 'InAuctionItemsTable';\r\n        this.$table = $('#' + this.tableId);\r\n        this.$tbody = this.$table.children('tbody').first();\r\n        this.search = new _filter_searchItems__WEBPACK_IMPORTED_MODULE_2__[\"default\"](this.$table.closest('div').find('input[type=\"search\"]'));\r\n        this.selectList = new _filter_selectListOfAmountPages__WEBPACK_IMPORTED_MODULE_3__[\"default\"](this.$table.closest('div').find('select'));\r\n        this.orderLinksManager = new _manager_orderLinksManager__WEBPACK_IMPORTED_MODULE_4__[\"default\"](this.$table.children('thead').find('th a'));\r\n        this.paging = new _pagination__WEBPACK_IMPORTED_MODULE_5__[\"default\"]($('#' + this.containerId).find('ul.pagination'), this.selectList.GetSelectedOptionValue, this.selectList);\r\n        this.search.add(this);\r\n        this.selectList.add(this.paging);\r\n        this.selectList.add(this);\r\n        this.orderLinksManager.add(this);\r\n        this.paging.add(this);\r\n        this.criteriaManager = new _manager_criteriaManager__WEBPACK_IMPORTED_MODULE_1__[\"default\"](this.orderLinksManager, this.search, this.selectList, this.paging);\r\n    }\r\n    ;\r\n    events() {\r\n        const $cancelButtons = $('.' + this.cancelAuctionButtonsClass);\r\n        $cancelButtons.on('click', (e) => { this.btnCancelOnClick(e); });\r\n        const $btnCancelConfirm = $('#' + this.cancenAuctionItemConfirmId);\r\n        $btnCancelConfirm.on('click', (e) => { this.btnCancelConfirmOnClick(e); });\r\n    }\r\n    ;\r\n    btnCancelOnClick(e) {\r\n        const $clicked = $(e.currentTarget);\r\n        const id = $clicked.data('id');\r\n        $('#' + this.cancenAuctionItemConfirmId).attr('data-id', id);\r\n    }\r\n    ;\r\n    btnCancelConfirmOnClick(e) {\r\n        const $btnConfirm = $(e.currentTarget);\r\n        const id = $btnConfirm.data('id');\r\n        const verificationToken = $('#DeleteItemModal').find('input[name=\"__RequestVerificationToken\"]').val();\r\n        this.itemAjax.cancelItemAuction(id, verificationToken).then(() => {\r\n            window.location.href = '/customer/item';\r\n            console.log('Item auction canceled');\r\n        }).catch((e) => {\r\n            console.log('cancel item auction error');\r\n        });\r\n    }\r\n    ;\r\n    update() {\r\n        this.renderTBody();\r\n    }\r\n    ;\r\n    renderTBody() {\r\n        const criteria = this.criteriaManager.GetCriteria;\r\n        this.itemAjax.getInAuctionItems(criteria).then((result) => {\r\n            if (result.items.length !== 0) {\r\n                const $body = this.getTBody(result.items);\r\n                this.$tbody.empty();\r\n                this.$tbody.append($body.children());\r\n                this.events();\r\n                this.paging.generatePagination(result.totalAmount);\r\n            }\r\n            else {\r\n                this.$tbody.empty();\r\n            }\r\n        }).catch((e) => { console.log('item in auction error'); });\r\n    }\r\n    ;\r\n    getTr(item) {\r\n        let $tr = $('<tr>');\r\n        $tr.append($('<td>').text(item.categoryName), $('<td>').append($('<a>')\r\n            .attr('href', '/item/item/' + item.id)\r\n            .text(item.name)), $('<td>').text(this.formatter.formatPrice(item.buyNowPrice)), $('<td>').html(this.formatter.formatDate(new Date(item.auctionStartDateMiliseconds))), $('<td>').html(this.formatter.formatDate(new Date(item.auctionEndDateMiliseconds))), $('<td>').text(item.deliveryMethod), $('<td>').append($('<a>')\r\n            .attr('href', '/customer/item/getItemBids/' + item.id)\r\n            .attr('role', 'button')\r\n            .addClass('btn btn-info btn-sm')\r\n            .text('Sprawdź')), $('<td>').append($('<button>')\r\n            .addClass('btn btn-warning btn-sm btn-cancel-auction')\r\n            .attr('data-id', item.id)\r\n            .attr('data-toggle', 'modal')\r\n            .attr('data-target', '#CancelItemAuctionModal')\r\n            .text('Anuluj')));\r\n        return $tr;\r\n    }\r\n    ;\r\n}\r\n\n\n//# sourceURL=webpack:///./Client/ts/customer/implement/table/tableOfInAuctionItems.ts?");

/***/ }),

/***/ "./Client/ts/enum/status.ts":
/*!**********************************!*\
  !*** ./Client/ts/enum/status.ts ***!
  \**********************************/
/*! exports provided: Status */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"Status\", function() { return Status; });\nvar Status;\r\n(function (Status) {\r\n    Status[Status[\"Waiting\"] = 1] = \"Waiting\";\r\n    Status[Status[\"InAuction\"] = 2] = \"InAuction\";\r\n    Status[Status[\"Bought\"] = 3] = \"Bought\";\r\n})(Status || (Status = {}));\r\n;\r\n\n\n//# sourceURL=webpack:///./Client/ts/enum/status.ts?");

/***/ }),

/***/ "./Client/ts/formatter.ts":
/*!********************************!*\
  !*** ./Client/ts/formatter.ts ***!
  \********************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return Formatter; });\nclass Formatter {\r\n    constructor(currencySign = 'pln') {\r\n        this.currencySign = currencySign;\r\n    }\r\n    ;\r\n    formatPrice(price) {\r\n        let formatedPrice = price.toFixed(2);\r\n        formatedPrice += ' ' + this.currencySign;\r\n        return formatedPrice;\r\n    }\r\n    ;\r\n    formatDate(date) {\r\n        const stringDate = date.toLocaleDateString();\r\n        const stringTime = date.toLocaleTimeString();\r\n        let formatDate = '<span>' + stringDate + '</span> <br/> <span>' + stringTime + '</span>';\r\n        return formatDate;\r\n    }\r\n    ;\r\n}\r\n;\r\n\n\n//# sourceURL=webpack:///./Client/ts/formatter.ts?");

/***/ }),

/***/ "./Client/ts/pagination.ts":
/*!*********************************!*\
  !*** ./Client/ts/pagination.ts ***!
  \*********************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return Pagination; });\n/* harmony import */ var _abstract_observable__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./abstract/observable */ \"./Client/ts/abstract/observable.ts\");\n\r\nclass Pagination extends _abstract_observable__WEBPACK_IMPORTED_MODULE_0__[\"default\"] {\r\n    constructor($paginationUl, pageSize, selectList) {\r\n        super();\r\n        this.$paginationUl = $paginationUl;\r\n        this.pageSize = pageSize;\r\n        this.selectList = selectList;\r\n        this.pageIndex = 1;\r\n    }\r\n    ;\r\n    update() {\r\n        this.pageIndex = 1;\r\n        this.pageSize = this.selectList.GetSelectedOptionValue;\r\n    }\r\n    ;\r\n    events() {\r\n        this.$paginationUl.children('li').on('click', (e) => { this.pagingItemOnClick(e); });\r\n    }\r\n    ;\r\n    get PageIndex() {\r\n        return this.pageIndex;\r\n    }\r\n    ;\r\n    activePagingItem($li) {\r\n        $li.addClass('active');\r\n    }\r\n    ;\r\n    deactivePagingItem($li) {\r\n        $li.remove('active');\r\n    }\r\n    ;\r\n    getPagingItemByCurrentIndex() {\r\n        const $items = this.$paginationUl.children('li'), length = $items.length;\r\n        let i = 0, $li;\r\n        for (i; i < length; i += 1) {\r\n            $li = $($items.get(i));\r\n            if ($li.data('index') == this.pageIndex) {\r\n                return $li;\r\n            }\r\n        }\r\n    }\r\n    ;\r\n    getActivePagingItem() {\r\n        const $items = this.$paginationUl.children('li'), length = $items.length;\r\n        let i = 0, $li;\r\n        for (i; i < length; i += 1) {\r\n            $li = $($items.get(i));\r\n            if ($li.hasClass('active')) {\r\n                return $li;\r\n            }\r\n        }\r\n    }\r\n    ;\r\n    isArrow($clicked) {\r\n        if ($clicked.data('index') === undefined)\r\n            return true;\r\n        return false;\r\n    }\r\n    ;\r\n    handleArrow($li) {\r\n        const arrow = $li.data('arrow');\r\n        if (arrow === 'left') {\r\n            this.moveLeft();\r\n        }\r\n        if (arrow === 'right') {\r\n            this.moveRight();\r\n        }\r\n    }\r\n    moveLeft() {\r\n        if (this.pageIndex > 1) {\r\n            this.pageIndex -= 1;\r\n            const $li = this.getPagingItemByCurrentIndex();\r\n            this.activePagingItem($li);\r\n        }\r\n    }\r\n    ;\r\n    moveRight() {\r\n        if (this.pageIndex < Math.ceil(this.totalAmount / this.pageSize)) {\r\n            this.pageIndex += 1;\r\n            const $li = this.getPagingItemByCurrentIndex();\r\n            this.activePagingItem($li);\r\n        }\r\n    }\r\n    ;\r\n    pagingItemOnClick(e) {\r\n        e.preventDefault();\r\n        const $clickced = $(e.currentTarget);\r\n        if (!this.isArrow($clickced))\r\n            this.pageIndex = $clickced.data('index');\r\n        else\r\n            this.handleArrow($clickced);\r\n        this.notify();\r\n    }\r\n    ;\r\n    generatePagination(totalAmount) {\r\n        this.totalAmount = totalAmount;\r\n        const firstArrow = this.$paginationUl.children('li').first();\r\n        const lastArrow = this.$paginationUl.children('li').last();\r\n        this.$paginationUl.empty();\r\n        this.$paginationUl.append(firstArrow);\r\n        this.$paginationUl.append(lastArrow);\r\n        const length = Math.ceil(totalAmount / this.pageSize);\r\n        let i = 0, $li;\r\n        for (i; i < length; i += 1) {\r\n            $li = this.getPagingItem(i + 1);\r\n            this.addListItem($li);\r\n        }\r\n        const $active = this.getPagingItemByCurrentIndex();\r\n        this.events();\r\n        this.activePagingItem($active);\r\n    }\r\n    ;\r\n    getPagingItem(index) {\r\n        let $li = $('<li>'), $a = $('<a>');\r\n        $a.addClass('page-link');\r\n        $a.attr('href', '#');\r\n        $a.text(index);\r\n        $li.addClass('page-item');\r\n        $li.attr('data-index', index);\r\n        $li.append($a);\r\n        return $li;\r\n    }\r\n    ;\r\n    addListItem($li) {\r\n        $li.insertBefore(this.$paginationUl.children().last());\r\n    }\r\n    ;\r\n}\r\n;\r\n\n\n//# sourceURL=webpack:///./Client/ts/pagination.ts?");

/***/ })

/******/ });