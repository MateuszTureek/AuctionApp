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
/******/ 	return __webpack_require__(__webpack_require__.s = "./Client/ts/presentation/auctions.ts");
/******/ })
/************************************************************************/
/******/ ({

/***/ "./Client/ts/auctionClearSession.ts":
/*!******************************************!*\
  !*** ./Client/ts/auctionClearSession.ts ***!
  \******************************************/
/*! exports provided: AuctionSession */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"AuctionSession\", function() { return AuctionSession; });\n/* harmony import */ var _settings_constant__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./settings/constant */ \"./Client/ts/settings/constant.ts\");\n\r\nclass AuctionSession {\r\n    static clear() {\r\n        $('#AuctionLink').on('click', () => {\r\n            sessionStorage.removeItem(_settings_constant__WEBPACK_IMPORTED_MODULE_0__[\"CATEGORY_KEY\"]);\r\n            sessionStorage.removeItem(_settings_constant__WEBPACK_IMPORTED_MODULE_0__[\"SUBCATEGORY_KEY\"]);\r\n            sessionStorage.removeItem(_settings_constant__WEBPACK_IMPORTED_MODULE_0__[\"SORT_OPTION_KEY\"]);\r\n            sessionStorage.removeItem(_settings_constant__WEBPACK_IMPORTED_MODULE_0__[\"PAGING_KEY\"]);\r\n        });\r\n    }\r\n}\r\n;\r\n\n\n//# sourceURL=webpack:///./Client/ts/auctionClearSession.ts?");

/***/ }),

/***/ "./Client/ts/linkActivator/categoryLinkActivator.ts":
/*!**********************************************************!*\
  !*** ./Client/ts/linkActivator/categoryLinkActivator.ts ***!
  \**********************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return CategoryLinkActivator; });\n/* harmony import */ var _linkActivator__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./linkActivator */ \"./Client/ts/linkActivator/linkActivator.ts\");\n/* harmony import */ var _settings_constant__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../settings/constant */ \"./Client/ts/settings/constant.ts\");\n\r\n\r\nclass CategoryLinkActivator extends _linkActivator__WEBPACK_IMPORTED_MODULE_0__[\"default\"] {\r\n    init() {\r\n        super.init();\r\n        const activatedDataId = parseInt(sessionStorage.getItem(this.sessionKey));\r\n        if (!isNaN(activatedDataId)) {\r\n            this.initSubcategory(activatedDataId);\r\n        }\r\n    }\r\n    ;\r\n    initSubcategory(activeCategoryDataId) {\r\n        const $link = this.findLinkByDataId(activeCategoryDataId);\r\n        const $subUl = $($link.closest('li').children('ul').first());\r\n        this.subcategoryLinkActivator = new _linkActivator__WEBPACK_IMPORTED_MODULE_0__[\"default\"]($subUl, 'active', _settings_constant__WEBPACK_IMPORTED_MODULE_1__[\"SUBCATEGORY_KEY\"]);\r\n        this.subcategoryLinkActivator.init();\r\n    }\r\n    ;\r\n    setupLink() {\r\n        super.setupLink();\r\n        this.showSubcategories();\r\n    }\r\n    ;\r\n    linkOnClick(e) {\r\n        super.linkOnClick(e);\r\n        sessionStorage.removeItem(_settings_constant__WEBPACK_IMPORTED_MODULE_1__[\"SUBCATEGORY_KEY\"]);\r\n    }\r\n    ;\r\n    showSubcategories() {\r\n        const activatedDataId = parseInt(sessionStorage.getItem(this.sessionKey));\r\n        if (!isNaN(activatedDataId)) {\r\n            const $activatedLink = this.findLinkByDataId(activatedDataId);\r\n            $activatedLink.closest('li').children('ul').first().removeClass('d-none');\r\n        }\r\n    }\r\n    ;\r\n}\r\n;\r\n\n\n//# sourceURL=webpack:///./Client/ts/linkActivator/categoryLinkActivator.ts?");

/***/ }),

/***/ "./Client/ts/linkActivator/linkActivator.ts":
/*!**************************************************!*\
  !*** ./Client/ts/linkActivator/linkActivator.ts ***!
  \**************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return LinkActivator; });\n/**\r\n * Class LinkActivator activates link in ul. Using session storage.\r\n */\r\nclass LinkActivator {\r\n    constructor($ulElem, active, sessionKey) {\r\n        this.$ulElem = $ulElem;\r\n        this.active = active;\r\n        this.sessionKey = sessionKey;\r\n        this.init();\r\n    }\r\n    ;\r\n    init() {\r\n        this.$linkCollection = this.$ulElem.children('li').children('a');\r\n        this.$linkCollection.on('click', (e) => { this.linkOnClick(e); });\r\n        this.setupLink();\r\n    }\r\n    ;\r\n    linkOnClick(e) {\r\n        e.stopPropagation();\r\n        const $clickedLink = $(e.target);\r\n        const clickedDataId = $clickedLink.closest('li').data('id');\r\n        const activedDataId = parseInt(sessionStorage.getItem(this.sessionKey));\r\n        if (isNaN(activedDataId)) {\r\n            sessionStorage.setItem(this.sessionKey, clickedDataId);\r\n        }\r\n        else {\r\n            if (clickedDataId === activedDataId)\r\n                return;\r\n            const $activedLink = this.findLinkByDataId(activedDataId);\r\n            this.deactiveLink($activedLink);\r\n            sessionStorage.setItem(this.sessionKey, clickedDataId);\r\n        }\r\n    }\r\n    ;\r\n    setupLink() {\r\n        const activeDataId = parseInt(sessionStorage.getItem(this.sessionKey));\r\n        if (!isNaN(activeDataId)) {\r\n            const $link = this.findLinkByDataId(activeDataId);\r\n            this.activeLink($link);\r\n        }\r\n    }\r\n    ;\r\n    activeLink($link) {\r\n        const $li = $link.closest('li');\r\n        sessionStorage.setItem(this.sessionKey, $li.data('id'));\r\n        $link.addClass(this.active);\r\n    }\r\n    ;\r\n    deactiveLink($link) {\r\n        sessionStorage.removeItem(this.sessionKey);\r\n        $link.removeClass(this.active);\r\n    }\r\n    findLinkByDataId(dataId) {\r\n        let i = 0, $li;\r\n        const length = this.$linkCollection.length;\r\n        for (i; i < length; i += 1) {\r\n            $li = $(this.$linkCollection.get(i).closest('li'));\r\n            if ($li.data('id') == dataId) {\r\n                return $($li.children('a'));\r\n            }\r\n        }\r\n        throw Error('Missing dataId in current ulList.');\r\n    }\r\n    ;\r\n}\r\n;\r\n\n\n//# sourceURL=webpack:///./Client/ts/linkActivator/linkActivator.ts?");

/***/ }),

/***/ "./Client/ts/linkActivator/orderButtonLinkActivator.ts":
/*!*************************************************************!*\
  !*** ./Client/ts/linkActivator/orderButtonLinkActivator.ts ***!
  \*************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return OrderButtonLinkActivator; });\nclass OrderButtonLinkActivator {\r\n    constructor($btnGroupDiv, active, sessionKey) {\r\n        this.$btnGroupDiv = $btnGroupDiv;\r\n        this.active = active;\r\n        this.sessionKey = sessionKey;\r\n        this.init();\r\n    }\r\n    ;\r\n    init() {\r\n        this.$buttonLinks = this.$btnGroupDiv.children('a');\r\n        this.$buttonLinks.on('click', (e) => { this.linkOnClick(e); });\r\n        this.setupLink();\r\n    }\r\n    ;\r\n    setupLink() {\r\n        const valueOfActiveLink = sessionStorage.getItem(this.sessionKey);\r\n        if (valueOfActiveLink != null && valueOfActiveLink != '') {\r\n            this.deactiveLink();\r\n            const $activeLink = this.takeLinkByOrderByValue(valueOfActiveLink);\r\n            this.activeLink($activeLink);\r\n        }\r\n        else {\r\n            const $firstLink = this.$buttonLinks.first();\r\n            this.activeLink($firstLink);\r\n        }\r\n    }\r\n    ;\r\n    linkOnClick(e) {\r\n        const $clickedLink = $(e.target);\r\n        sessionStorage.setItem(this.sessionKey, $clickedLink.data('orderBy'));\r\n    }\r\n    ;\r\n    activeLink($link) {\r\n        sessionStorage.setItem(this.sessionKey, $link.data('orderBy'));\r\n        $link.addClass(this.active);\r\n    }\r\n    ;\r\n    deactiveLink() {\r\n        let i = 0, $link;\r\n        const length = this.$buttonLinks.length;\r\n        for (i; i < length; i += 1) {\r\n            $link = $(this.$buttonLinks.get(0));\r\n            if ($link.hasClass(this.active)) {\r\n                $link.removeClass(this.active);\r\n                sessionStorage.removeItem(this.sessionKey);\r\n            }\r\n        }\r\n    }\r\n    ;\r\n    takeLinkByOrderByValue(orderByValue) {\r\n        let i = 0, $link;\r\n        const length = this.$buttonLinks.length;\r\n        for (i; i < length; i += 1) {\r\n            $link = $(this.$buttonLinks.get(i));\r\n            if ($link.data('orderBy') === orderByValue) {\r\n                return $link;\r\n            }\r\n        }\r\n        throw new Error('Missing order by value in current group div.');\r\n    }\r\n    ;\r\n}\r\n;\r\n\n\n//# sourceURL=webpack:///./Client/ts/linkActivator/orderButtonLinkActivator.ts?");

/***/ }),

/***/ "./Client/ts/linkActivator/pagingLinkActivator.ts":
/*!********************************************************!*\
  !*** ./Client/ts/linkActivator/pagingLinkActivator.ts ***!
  \********************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return PagingLinkActivator; });\n/* harmony import */ var _linkActivator__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./linkActivator */ \"./Client/ts/linkActivator/linkActivator.ts\");\n\r\nclass PagingLinkActivator extends _linkActivator__WEBPACK_IMPORTED_MODULE_0__[\"default\"] {\r\n    init() {\r\n        this.$linkCollection = this.$ulElem.children('li').children('a').not(\":first\").not(\":last\");\r\n        this.$prevLink = $(this.$ulElem.children('li').first());\r\n        this.$nextLink = $(this.$ulElem.children('li').last());\r\n        this.$linkCollection.on('click', (e) => { this.linkOnClick(e); });\r\n        this.$prevLink.on('click', () => { this.prevLinkOnClick(); });\r\n        this.$nextLink.on('click', () => { this.nextLinkOnClick(); });\r\n        this.setupLink();\r\n        this.setupActivateNextAndPrevLink();\r\n    }\r\n    ;\r\n    prevLinkOnClick() {\r\n        const activeDataId = parseInt(sessionStorage.getItem(this.sessionKey));\r\n        if (!isNaN(activeDataId)) {\r\n            const $link = this.findLinkByDataId(activeDataId);\r\n            const $prevSibling = $link.closest('li').prev('li');\r\n            sessionStorage.setItem(this.sessionKey, $prevSibling.data('id'));\r\n        }\r\n    }\r\n    ;\r\n    nextLinkOnClick() {\r\n        const activeDataId = parseInt(sessionStorage.getItem(this.sessionKey));\r\n        if (!isNaN(activeDataId)) {\r\n            const $link = this.findLinkByDataId(activeDataId);\r\n            const $nextSibling = $link.closest('li').next('li');\r\n            sessionStorage.setItem(this.sessionKey, $nextSibling.data('id'));\r\n        }\r\n    }\r\n    ;\r\n    setupLink() {\r\n        const activeDataId = parseInt(sessionStorage.getItem(this.sessionKey));\r\n        if (!isNaN(activeDataId)) {\r\n            const $link = this.findLinkByDataId(activeDataId);\r\n            this.activeLink($link);\r\n        }\r\n        else {\r\n            const $firstLink = $(this.$linkCollection.first());\r\n            const dataId = $firstLink.closest('li').data('id');\r\n            sessionStorage.setItem(this.sessionKey, dataId);\r\n            this.activeLink($firstLink);\r\n        }\r\n    }\r\n    ;\r\n    activeLink($link) {\r\n        const $li = $link.closest('li');\r\n        sessionStorage.setItem(this.sessionKey, $li.data('id'));\r\n        $li.addClass(this.active);\r\n    }\r\n    ;\r\n    deactiveLink($link) {\r\n        const $li = $link.closest('li');\r\n        sessionStorage.removeItem(this.sessionKey);\r\n        $li.removeClass(this.active);\r\n    }\r\n    setupActivateNextAndPrevLink() {\r\n        const activeDataId = parseInt(sessionStorage.getItem(this.sessionKey));\r\n        if (isNaN(activeDataId)) {\r\n            throw new Error('Any pagination link is not active.');\r\n        }\r\n        const firstDataId = $(this.$linkCollection.first()).closest('li').data('id');\r\n        const lastDataId = $(this.$linkCollection.last()).closest('li').data('id');\r\n        if (activeDataId === firstDataId) {\r\n            this.disableLink(this.$prevLink);\r\n        }\r\n        if (activeDataId === lastDataId) {\r\n            this.disableLink(this.$nextLink);\r\n        }\r\n    }\r\n    ;\r\n    disableLink($link) {\r\n        const $li = $link.closest('li');\r\n        $li.addClass('disabled');\r\n    }\r\n    ;\r\n    enableLink($link) {\r\n        const $li = $link.closest('li');\r\n        $li.removeClass('disabled');\r\n    }\r\n    ;\r\n}\r\n;\r\n\n\n//# sourceURL=webpack:///./Client/ts/linkActivator/pagingLinkActivator.ts?");

/***/ }),

/***/ "./Client/ts/presentation/auctions.ts":
/*!********************************************!*\
  !*** ./Client/ts/presentation/auctions.ts ***!
  \********************************************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony import */ var _settings_constant__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../settings/constant */ \"./Client/ts/settings/constant.ts\");\n/* harmony import */ var _auctionClearSession__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../auctionClearSession */ \"./Client/ts/auctionClearSession.ts\");\n/* harmony import */ var _linkActivator_categoryLinkActivator__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../linkActivator/categoryLinkActivator */ \"./Client/ts/linkActivator/categoryLinkActivator.ts\");\n/* harmony import */ var _linkActivator_orderButtonLinkActivator__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../linkActivator/orderButtonLinkActivator */ \"./Client/ts/linkActivator/orderButtonLinkActivator.ts\");\n/* harmony import */ var _linkActivator_pagingLinkActivator__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../linkActivator/pagingLinkActivator */ \"./Client/ts/linkActivator/pagingLinkActivator.ts\");\n\r\n\r\n\r\n\r\n\r\n/*\r\n * Main - auctions.ts\r\n */\r\n$(document).ready(() => {\r\n    const categoryLinkActovator = new _linkActivator_categoryLinkActivator__WEBPACK_IMPORTED_MODULE_2__[\"default\"]($('#Categories'), 'active', _settings_constant__WEBPACK_IMPORTED_MODULE_0__[\"CATEGORY_KEY\"]);\r\n    const buttonLinkActivator = new _linkActivator_orderButtonLinkActivator__WEBPACK_IMPORTED_MODULE_3__[\"default\"]($('#OrderByGroupButton'), 'active', _settings_constant__WEBPACK_IMPORTED_MODULE_0__[\"SORT_OPTION_KEY\"]);\r\n    const pagingLinkActivator = new _linkActivator_pagingLinkActivator__WEBPACK_IMPORTED_MODULE_4__[\"default\"]($('#PaginationList'), 'active', _settings_constant__WEBPACK_IMPORTED_MODULE_0__[\"PAGING_KEY\"]);\r\n    _auctionClearSession__WEBPACK_IMPORTED_MODULE_1__[\"AuctionSession\"].clear();\r\n});\r\n\n\n//# sourceURL=webpack:///./Client/ts/presentation/auctions.ts?");

/***/ }),

/***/ "./Client/ts/settings/constant.ts":
/*!****************************************!*\
  !*** ./Client/ts/settings/constant.ts ***!
  \****************************************/
/*! exports provided: CATEGORY_KEY, SUBCATEGORY_KEY, ACTIVE_NAV_LINK_KEY, SORT_OPTION_KEY, PAGING_KEY */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"CATEGORY_KEY\", function() { return CATEGORY_KEY; });\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"SUBCATEGORY_KEY\", function() { return SUBCATEGORY_KEY; });\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"ACTIVE_NAV_LINK_KEY\", function() { return ACTIVE_NAV_LINK_KEY; });\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"SORT_OPTION_KEY\", function() { return SORT_OPTION_KEY; });\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"PAGING_KEY\", function() { return PAGING_KEY; });\n// global session storage keys\r\nconst CATEGORY_KEY = \"ActiveCategory\";\r\nconst SUBCATEGORY_KEY = \"ActiveSubcategory\";\r\nconst ACTIVE_NAV_LINK_KEY = \"ActiveNavLink\";\r\nconst SORT_OPTION_KEY = \"ActiveSortOption\";\r\nconst PAGING_KEY = \"ActiveAuctionPage\";\r\n\n\n//# sourceURL=webpack:///./Client/ts/settings/constant.ts?");

/***/ })

/******/ });