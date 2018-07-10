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
/******/ 	return __webpack_require__(__webpack_require__.s = "./Client/ts/presentation/home.ts");
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

/***/ "./Client/ts/linkActivator/mainNavLinkActivator.ts":
/*!*********************************************************!*\
  !*** ./Client/ts/linkActivator/mainNavLinkActivator.ts ***!
  \*********************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return MainNavLinkActivator; });\nclass MainNavLinkActivator {\r\n    constructor($navElem, active) {\r\n        this.$navElem = $navElem;\r\n        this.active = active;\r\n        this.init();\r\n    }\r\n    ;\r\n    init() {\r\n        this.$linkCollection = this.$navElem.children('a');\r\n        this.setRigidlyLinksToCollection();\r\n        this.setupLink();\r\n    }\r\n    ;\r\n    setRigidlyLinksToCollection() {\r\n        var $cartLink = $('#Cart').find('a').first();\r\n        this.$linkCollection = this.$linkCollection.add($cartLink);\r\n    }\r\n    setupLink() {\r\n        const href = window.location.pathname;\r\n        const $link = this.getLinkByHref(href);\r\n        this.deactiveLink();\r\n        this.activeLink($link);\r\n    }\r\n    ;\r\n    getLinkByHref(href) {\r\n        let i = 0, $link;\r\n        const length = this.$linkCollection.length;\r\n        for (i; i < length; i += 1) {\r\n            $link = $(this.$linkCollection.get(i));\r\n            if ($link.attr('href') === href) {\r\n                return $link;\r\n            }\r\n        }\r\n        throw new Error(\"Not found matching nav link.\");\r\n    }\r\n    ;\r\n    activeLink($link) {\r\n        $link.addClass(this.active);\r\n    }\r\n    ;\r\n    deactiveLink() {\r\n        let i = 0, $link;\r\n        const length = this.$linkCollection.length;\r\n        for (i; i < length; i += 1) {\r\n            $link = $(this.$linkCollection.get(i));\r\n            if ($link.hasClass(this.active)) {\r\n                $link.remove(this.active);\r\n            }\r\n        }\r\n    }\r\n    ;\r\n}\r\n;\r\n\n\n//# sourceURL=webpack:///./Client/ts/linkActivator/mainNavLinkActivator.ts?");

/***/ }),

/***/ "./Client/ts/presentation/home.ts":
/*!****************************************!*\
  !*** ./Client/ts/presentation/home.ts ***!
  \****************************************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony import */ var _auctionClearSession__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../auctionClearSession */ \"./Client/ts/auctionClearSession.ts\");\n/* harmony import */ var _linkActivator_mainNavLinkActivator__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../linkActivator/mainNavLinkActivator */ \"./Client/ts/linkActivator/mainNavLinkActivator.ts\");\n\r\n\r\n/*\r\n * Home - home.ts\r\n */\r\n$(document).ready(() => {\r\n    const mainNav = new _linkActivator_mainNavLinkActivator__WEBPACK_IMPORTED_MODULE_1__[\"default\"]($('#MainNav'), 'active');\r\n    _auctionClearSession__WEBPACK_IMPORTED_MODULE_0__[\"AuctionSession\"].clear();\r\n});\r\n\n\n//# sourceURL=webpack:///./Client/ts/presentation/home.ts?");

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