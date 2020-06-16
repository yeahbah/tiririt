function _defineProperty(obj, key, value) { if (key in obj) { Object.defineProperty(obj, key, { value: value, enumerable: true, configurable: true, writable: true }); } else { obj[key] = value; } return obj; }

function _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } }

function _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); return Constructor; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"], {
  /***/
  "./$$_lazy_route_resource lazy recursive":
  /*!******************************************************!*\
    !*** ./$$_lazy_route_resource lazy namespace object ***!
    \******************************************************/

  /*! no static exports found */

  /***/
  function $$_lazy_route_resourceLazyRecursive(module, exports) {
    function webpackEmptyAsyncContext(req) {
      // Here Promise.resolve().then() is used instead of new Promise() to prevent
      // uncaught exception popping up in devtools
      return Promise.resolve().then(function () {
        var e = new Error("Cannot find module '" + req + "'");
        e.code = 'MODULE_NOT_FOUND';
        throw e;
      });
    }

    webpackEmptyAsyncContext.keys = function () {
      return [];
    };

    webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
    module.exports = webpackEmptyAsyncContext;
    webpackEmptyAsyncContext.id = "./$$_lazy_route_resource lazy recursive";
    /***/
  },

  /***/
  "./src/app/api-authorization/api-authorization.constants.ts":
  /*!******************************************************************!*\
    !*** ./src/app/api-authorization/api-authorization.constants.ts ***!
    \******************************************************************/

  /*! exports provided: ApplicationName, ReturnUrlType, QueryParameterNames, LogoutActions, LoginActions, ApplicationPaths */

  /***/
  function srcAppApiAuthorizationApiAuthorizationConstantsTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "ApplicationName", function () {
      return ApplicationName;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "ReturnUrlType", function () {
      return ReturnUrlType;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "QueryParameterNames", function () {
      return QueryParameterNames;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "LogoutActions", function () {
      return LogoutActions;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "LoginActions", function () {
      return LoginActions;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "ApplicationPaths", function () {
      return ApplicationPaths;
    });

    var ApplicationName = 'Tiririt';
    var ReturnUrlType = 'returnUrl';
    var QueryParameterNames = {
      ReturnUrl: ReturnUrlType,
      Message: 'message'
    };
    var LogoutActions = {
      LogoutCallback: 'logout-callback',
      Logout: 'logout',
      LoggedOut: 'logged-out'
    };
    var LoginActions = {
      Login: 'login',
      LoginCallback: 'login-callback',
      LoginFailed: 'login-failed',
      Profile: 'profile',
      Register: 'register'
    };
    var applicationPaths = {
      DefaultLoginRedirectPath: '/',
      ApiAuthorizationClientConfigurationUrl: "https://localhost/tiriritapi/_configuration/".concat(ApplicationName),
      Login: "authentication/".concat(LoginActions.Login),
      LoginFailed: "authentication/".concat(LoginActions.LoginFailed),
      LoginCallback: "authentication/".concat(LoginActions.LoginCallback),
      Register: "authentication/".concat(LoginActions.Register),
      Profile: "authentication/".concat(LoginActions.Profile),
      LogOut: "authentication/".concat(LogoutActions.Logout),
      LoggedOut: "authentication/".concat(LogoutActions.LoggedOut),
      LogOutCallback: "authentication/".concat(LogoutActions.LogoutCallback),
      LoginPathComponents: [],
      LoginFailedPathComponents: [],
      LoginCallbackPathComponents: [],
      RegisterPathComponents: [],
      ProfilePathComponents: [],
      LogOutPathComponents: [],
      LoggedOutPathComponents: [],
      LogOutCallbackPathComponents: [],
      IdentityRegisterPath: 'https://localhost/tiriritapi/Identity/Account/Register',
      IdentityManagePath: 'https://localhost/tiriritapi/Identity/Account/Manage'
    };
    applicationPaths = Object.assign(Object.assign({}, applicationPaths), {
      LoginPathComponents: applicationPaths.Login.split('/'),
      LoginFailedPathComponents: applicationPaths.LoginFailed.split('/'),
      RegisterPathComponents: applicationPaths.Register.split('/'),
      ProfilePathComponents: applicationPaths.Profile.split('/'),
      LogOutPathComponents: applicationPaths.LogOut.split('/'),
      LoggedOutPathComponents: applicationPaths.LoggedOut.split('/'),
      LogOutCallbackPathComponents: applicationPaths.LogOutCallback.split('/')
    });
    var ApplicationPaths = applicationPaths;
    /***/
  },

  /***/
  "./src/app/api-authorization/api-authorization.module.ts":
  /*!***************************************************************!*\
    !*** ./src/app/api-authorization/api-authorization.module.ts ***!
    \***************************************************************/

  /*! exports provided: ApiAuthorizationModule */

  /***/
  function srcAppApiAuthorizationApiAuthorizationModuleTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "ApiAuthorizationModule", function () {
      return ApiAuthorizationModule;
    });
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
    /* harmony import */


    var _angular_common__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/common */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/common.js");
    /* harmony import */


    var _login_menu_login_menu_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! ./login-menu/login-menu.component */
    "./src/app/api-authorization/login-menu/login-menu.component.ts");
    /* harmony import */


    var _login_login_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
    /*! ./login/login.component */
    "./src/app/api-authorization/login/login.component.ts");
    /* harmony import */


    var _logout_logout_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(
    /*! ./logout/logout.component */
    "./src/app/api-authorization/logout/logout.component.ts");
    /* harmony import */


    var _angular_router__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(
    /*! @angular/router */
    "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");
    /* harmony import */


    var _api_authorization_constants__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(
    /*! ./api-authorization.constants */
    "./src/app/api-authorization/api-authorization.constants.ts");
    /* harmony import */


    var _angular_common_http__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(
    /*! @angular/common/http */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/http.js");

    var ApiAuthorizationModule = function ApiAuthorizationModule() {
      _classCallCheck(this, ApiAuthorizationModule);
    };

    ApiAuthorizationModule.ɵmod = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineNgModule"]({
      type: ApiAuthorizationModule
    });
    ApiAuthorizationModule.ɵinj = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineInjector"]({
      factory: function ApiAuthorizationModule_Factory(t) {
        return new (t || ApiAuthorizationModule)();
      },
      imports: [[_angular_common__WEBPACK_IMPORTED_MODULE_1__["CommonModule"], _angular_common_http__WEBPACK_IMPORTED_MODULE_7__["HttpClientModule"], _angular_router__WEBPACK_IMPORTED_MODULE_5__["RouterModule"].forChild([{
        path: _api_authorization_constants__WEBPACK_IMPORTED_MODULE_6__["ApplicationPaths"].Register,
        component: _login_login_component__WEBPACK_IMPORTED_MODULE_3__["LoginComponent"]
      }, {
        path: _api_authorization_constants__WEBPACK_IMPORTED_MODULE_6__["ApplicationPaths"].Profile,
        component: _login_login_component__WEBPACK_IMPORTED_MODULE_3__["LoginComponent"]
      }, {
        path: _api_authorization_constants__WEBPACK_IMPORTED_MODULE_6__["ApplicationPaths"].Login,
        component: _login_login_component__WEBPACK_IMPORTED_MODULE_3__["LoginComponent"]
      }, {
        path: _api_authorization_constants__WEBPACK_IMPORTED_MODULE_6__["ApplicationPaths"].LoginFailed,
        component: _login_login_component__WEBPACK_IMPORTED_MODULE_3__["LoginComponent"]
      }, {
        path: _api_authorization_constants__WEBPACK_IMPORTED_MODULE_6__["ApplicationPaths"].LoginCallback,
        component: _login_login_component__WEBPACK_IMPORTED_MODULE_3__["LoginComponent"]
      }, {
        path: _api_authorization_constants__WEBPACK_IMPORTED_MODULE_6__["ApplicationPaths"].LogOut,
        component: _logout_logout_component__WEBPACK_IMPORTED_MODULE_4__["LogoutComponent"]
      }, {
        path: _api_authorization_constants__WEBPACK_IMPORTED_MODULE_6__["ApplicationPaths"].LoggedOut,
        component: _logout_logout_component__WEBPACK_IMPORTED_MODULE_4__["LogoutComponent"]
      }, {
        path: _api_authorization_constants__WEBPACK_IMPORTED_MODULE_6__["ApplicationPaths"].LogOutCallback,
        component: _logout_logout_component__WEBPACK_IMPORTED_MODULE_4__["LogoutComponent"]
      }])]]
    });

    (function () {
      (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵsetNgModuleScope"](ApiAuthorizationModule, {
        declarations: [_login_menu_login_menu_component__WEBPACK_IMPORTED_MODULE_2__["LoginMenuComponent"], _login_login_component__WEBPACK_IMPORTED_MODULE_3__["LoginComponent"], _logout_logout_component__WEBPACK_IMPORTED_MODULE_4__["LogoutComponent"]],
        imports: [_angular_common__WEBPACK_IMPORTED_MODULE_1__["CommonModule"], _angular_common_http__WEBPACK_IMPORTED_MODULE_7__["HttpClientModule"], _angular_router__WEBPACK_IMPORTED_MODULE_5__["RouterModule"]],
        exports: [_login_menu_login_menu_component__WEBPACK_IMPORTED_MODULE_2__["LoginMenuComponent"], _login_login_component__WEBPACK_IMPORTED_MODULE_3__["LoginComponent"], _logout_logout_component__WEBPACK_IMPORTED_MODULE_4__["LogoutComponent"]]
      });
    })();
    /*@__PURE__*/


    (function () {
      _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](ApiAuthorizationModule, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"],
        args: [{
          imports: [_angular_common__WEBPACK_IMPORTED_MODULE_1__["CommonModule"], _angular_common_http__WEBPACK_IMPORTED_MODULE_7__["HttpClientModule"], _angular_router__WEBPACK_IMPORTED_MODULE_5__["RouterModule"].forChild([{
            path: _api_authorization_constants__WEBPACK_IMPORTED_MODULE_6__["ApplicationPaths"].Register,
            component: _login_login_component__WEBPACK_IMPORTED_MODULE_3__["LoginComponent"]
          }, {
            path: _api_authorization_constants__WEBPACK_IMPORTED_MODULE_6__["ApplicationPaths"].Profile,
            component: _login_login_component__WEBPACK_IMPORTED_MODULE_3__["LoginComponent"]
          }, {
            path: _api_authorization_constants__WEBPACK_IMPORTED_MODULE_6__["ApplicationPaths"].Login,
            component: _login_login_component__WEBPACK_IMPORTED_MODULE_3__["LoginComponent"]
          }, {
            path: _api_authorization_constants__WEBPACK_IMPORTED_MODULE_6__["ApplicationPaths"].LoginFailed,
            component: _login_login_component__WEBPACK_IMPORTED_MODULE_3__["LoginComponent"]
          }, {
            path: _api_authorization_constants__WEBPACK_IMPORTED_MODULE_6__["ApplicationPaths"].LoginCallback,
            component: _login_login_component__WEBPACK_IMPORTED_MODULE_3__["LoginComponent"]
          }, {
            path: _api_authorization_constants__WEBPACK_IMPORTED_MODULE_6__["ApplicationPaths"].LogOut,
            component: _logout_logout_component__WEBPACK_IMPORTED_MODULE_4__["LogoutComponent"]
          }, {
            path: _api_authorization_constants__WEBPACK_IMPORTED_MODULE_6__["ApplicationPaths"].LoggedOut,
            component: _logout_logout_component__WEBPACK_IMPORTED_MODULE_4__["LogoutComponent"]
          }, {
            path: _api_authorization_constants__WEBPACK_IMPORTED_MODULE_6__["ApplicationPaths"].LogOutCallback,
            component: _logout_logout_component__WEBPACK_IMPORTED_MODULE_4__["LogoutComponent"]
          }])],
          declarations: [_login_menu_login_menu_component__WEBPACK_IMPORTED_MODULE_2__["LoginMenuComponent"], _login_login_component__WEBPACK_IMPORTED_MODULE_3__["LoginComponent"], _logout_logout_component__WEBPACK_IMPORTED_MODULE_4__["LogoutComponent"]],
          exports: [_login_menu_login_menu_component__WEBPACK_IMPORTED_MODULE_2__["LoginMenuComponent"], _login_login_component__WEBPACK_IMPORTED_MODULE_3__["LoginComponent"], _logout_logout_component__WEBPACK_IMPORTED_MODULE_4__["LogoutComponent"]]
        }]
      }], null, null);
    })();
    /***/

  },

  /***/
  "./src/app/api-authorization/authorize.interceptor.ts":
  /*!************************************************************!*\
    !*** ./src/app/api-authorization/authorize.interceptor.ts ***!
    \************************************************************/

  /*! exports provided: AuthorizeInterceptor */

  /***/
  function srcAppApiAuthorizationAuthorizeInterceptorTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "AuthorizeInterceptor", function () {
      return AuthorizeInterceptor;
    });
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
    /* harmony import */


    var rxjs_operators__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! rxjs/operators */
    "./node_modules/rxjs/_esm2015/operators/index.js");
    /* harmony import */


    var _authorize_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! ./authorize.service */
    "./src/app/api-authorization/authorize.service.ts");

    var AuthorizeInterceptor = /*#__PURE__*/function () {
      function AuthorizeInterceptor(authorize) {
        _classCallCheck(this, AuthorizeInterceptor);

        this.authorize = authorize;
      }

      _createClass(AuthorizeInterceptor, [{
        key: "intercept",
        value: function intercept(req, next) {
          var _this = this;

          return this.authorize.getAccessToken().pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (token) {
            return _this.processRequestWithToken(token, req, next);
          }));
        } // Checks if there is an access_token available in the authorize service
        // and adds it to the request in case it's targeted at the same origin as the
        // single page application.

      }, {
        key: "processRequestWithToken",
        value: function processRequestWithToken(token, req, next) {
          if (!!token && this.isSameOriginUrl(req)) {
            req = req.clone({
              setHeaders: {
                Authorization: "Bearer ".concat(token)
              }
            });
          }

          return next.handle(req);
        }
      }, {
        key: "isSameOriginUrl",
        value: function isSameOriginUrl(req) {
          // It's an absolute url with the same origin.
          if (req.url.startsWith("".concat(window.location.origin, "/"))) {
            return true;
          } // It's a protocol relative url with the same origin.
          // For example: //www.example.com/api/Products


          if (req.url.startsWith("//".concat(window.location.host, "/"))) {
            return true;
          } // It's a relative url like /api/Products


          if (/^\/[^\/].*/.test(req.url)) {
            return true;
          } // It's an absolute or protocol relative url that
          // doesn't have the same origin.


          return false;
        }
      }]);

      return AuthorizeInterceptor;
    }();

    AuthorizeInterceptor.ɵfac = function AuthorizeInterceptor_Factory(t) {
      return new (t || AuthorizeInterceptor)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"](_authorize_service__WEBPACK_IMPORTED_MODULE_2__["AuthorizeService"]));
    };

    AuthorizeInterceptor.ɵprov = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineInjectable"]({
      token: AuthorizeInterceptor,
      factory: AuthorizeInterceptor.ɵfac,
      providedIn: 'root'
    });
    /*@__PURE__*/

    (function () {
      _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](AuthorizeInterceptor, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"],
        args: [{
          providedIn: 'root'
        }]
      }], function () {
        return [{
          type: _authorize_service__WEBPACK_IMPORTED_MODULE_2__["AuthorizeService"]
        }];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/app/api-authorization/authorize.service.ts":
  /*!********************************************************!*\
    !*** ./src/app/api-authorization/authorize.service.ts ***!
    \********************************************************/

  /*! exports provided: AuthenticationResultStatus, AuthorizeService */

  /***/
  function srcAppApiAuthorizationAuthorizeServiceTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "AuthenticationResultStatus", function () {
      return AuthenticationResultStatus;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "AuthorizeService", function () {
      return AuthorizeService;
    });
    /* harmony import */


    var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! tslib */
    "./node_modules/tslib/tslib.es6.js");
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
    /* harmony import */


    var oidc_client__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! oidc-client */
    "./node_modules/oidc-client/lib/oidc-client.min.js");
    /* harmony import */


    var oidc_client__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(oidc_client__WEBPACK_IMPORTED_MODULE_2__);
    /* harmony import */


    var rxjs__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
    /*! rxjs */
    "./node_modules/rxjs/_esm2015/index.js");
    /* harmony import */


    var rxjs_operators__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(
    /*! rxjs/operators */
    "./node_modules/rxjs/_esm2015/operators/index.js");
    /* harmony import */


    var _api_authorization_constants__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(
    /*! ./api-authorization.constants */
    "./src/app/api-authorization/api-authorization.constants.ts");

    var AuthenticationResultStatus;

    (function (AuthenticationResultStatus) {
      AuthenticationResultStatus[AuthenticationResultStatus["Success"] = 0] = "Success";
      AuthenticationResultStatus[AuthenticationResultStatus["Redirect"] = 1] = "Redirect";
      AuthenticationResultStatus[AuthenticationResultStatus["Fail"] = 2] = "Fail";
    })(AuthenticationResultStatus || (AuthenticationResultStatus = {}));

    var AuthorizeService = /*#__PURE__*/function () {
      function AuthorizeService() {
        _classCallCheck(this, AuthorizeService);

        // By default pop ups are disabled because they don't work properly on Edge.
        // If you want to enable pop up authentication simply set this flag to false.
        this.popUpDisabled = true;
        this.userSubject = new rxjs__WEBPACK_IMPORTED_MODULE_3__["BehaviorSubject"](null);
      }

      _createClass(AuthorizeService, [{
        key: "isAuthenticated",
        value: function isAuthenticated() {
          return this.getUser().pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["map"])(function (u) {
            return !!u;
          }));
        }
      }, {
        key: "getUser",
        value: function getUser() {
          var _this2 = this;

          return Object(rxjs__WEBPACK_IMPORTED_MODULE_3__["concat"])(this.userSubject.pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["take"])(1), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["filter"])(function (u) {
            return !!u;
          })), this.getUserFromStorage().pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["filter"])(function (u) {
            return !!u;
          }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["tap"])(function (u) {
            return _this2.userSubject.next(u);
          })), this.userSubject.asObservable());
        }
      }, {
        key: "getAccessToken",
        value: function getAccessToken() {
          var _this3 = this;

          return Object(rxjs__WEBPACK_IMPORTED_MODULE_3__["from"])(this.ensureUserManagerInitialized()).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["mergeMap"])(function () {
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_3__["from"])(_this3.userManager.getUser());
          }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["map"])(function (user) {
            return user && user.access_token;
          }));
        } // We try to authenticate the user in three different ways:
        // 1) We try to see if we can authenticate the user silently. This happens
        //    when the user is already logged in on the IdP and is done using a hidden iframe
        //    on the client.
        // 2) We try to authenticate the user using a PopUp Window. This might fail if there is a
        //    Pop-Up blocker or the user has disabled PopUps.
        // 3) If the two methods above fail, we redirect the browser to the IdP to perform a traditional
        //    redirect flow.

      }, {
        key: "signIn",
        value: function signIn(state) {
          return Object(tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"])(this, void 0, void 0, /*#__PURE__*/regeneratorRuntime.mark(function _callee() {
            var user;
            return regeneratorRuntime.wrap(function _callee$(_context) {
              while (1) {
                switch (_context.prev = _context.next) {
                  case 0:
                    _context.next = 2;
                    return this.ensureUserManagerInitialized();

                  case 2:
                    user = null;
                    _context.prev = 3;
                    _context.next = 6;
                    return this.userManager.signinSilent(this.createArguments());

                  case 6:
                    user = _context.sent;
                    this.userSubject.next(user.profile);
                    return _context.abrupt("return", this.success(state));

                  case 11:
                    _context.prev = 11;
                    _context.t0 = _context["catch"](3);
                    // User might not be authenticated, fallback to popup authentication
                    console.log('Silent authentication error: ', _context.t0);
                    _context.prev = 14;

                    if (!this.popUpDisabled) {
                      _context.next = 17;
                      break;
                    }

                    throw new Error('Popup disabled. Change \'authorize.service.ts:AuthorizeService.popupDisabled\' to false to enable it.');

                  case 17:
                    _context.next = 19;
                    return this.userManager.signinPopup(this.createArguments());

                  case 19:
                    user = _context.sent;
                    this.userSubject.next(user.profile);
                    return _context.abrupt("return", this.success(state));

                  case 24:
                    _context.prev = 24;
                    _context.t1 = _context["catch"](14);

                    if (!(_context.t1.message === 'Popup window closed')) {
                      _context.next = 30;
                      break;
                    }

                    return _context.abrupt("return", this.error('The user closed the window.'));

                  case 30:
                    if (!this.popUpDisabled) {
                      console.log('Popup authentication error: ', _context.t1);
                    }

                  case 31:
                    _context.prev = 31;
                    _context.next = 34;
                    return this.userManager.signinRedirect(this.createArguments(state));

                  case 34:
                    return _context.abrupt("return", this.redirect());

                  case 37:
                    _context.prev = 37;
                    _context.t2 = _context["catch"](31);
                    console.log('Redirect authentication error: ', _context.t2);
                    return _context.abrupt("return", this.error(_context.t2));

                  case 41:
                  case "end":
                    return _context.stop();
                }
              }
            }, _callee, this, [[3, 11], [14, 24], [31, 37]]);
          }));
        }
      }, {
        key: "completeSignIn",
        value: function completeSignIn(url) {
          return Object(tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"])(this, void 0, void 0, /*#__PURE__*/regeneratorRuntime.mark(function _callee2() {
            var user;
            return regeneratorRuntime.wrap(function _callee2$(_context2) {
              while (1) {
                switch (_context2.prev = _context2.next) {
                  case 0:
                    _context2.prev = 0;
                    _context2.next = 3;
                    return this.ensureUserManagerInitialized();

                  case 3:
                    _context2.next = 5;
                    return this.userManager.signinCallback(url);

                  case 5:
                    user = _context2.sent;
                    this.userSubject.next(user && user.profile);
                    return _context2.abrupt("return", this.success(user && user.state));

                  case 10:
                    _context2.prev = 10;
                    _context2.t0 = _context2["catch"](0);
                    console.log('There was an error signing in: ', _context2.t0);
                    return _context2.abrupt("return", this.error('There was an error signing in.'));

                  case 14:
                  case "end":
                    return _context2.stop();
                }
              }
            }, _callee2, this, [[0, 10]]);
          }));
        }
      }, {
        key: "signOut",
        value: function signOut(state) {
          return Object(tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"])(this, void 0, void 0, /*#__PURE__*/regeneratorRuntime.mark(function _callee3() {
            return regeneratorRuntime.wrap(function _callee3$(_context3) {
              while (1) {
                switch (_context3.prev = _context3.next) {
                  case 0:
                    _context3.prev = 0;

                    if (!this.popUpDisabled) {
                      _context3.next = 3;
                      break;
                    }

                    throw new Error('Popup disabled. Change \'authorize.service.ts:AuthorizeService.popupDisabled\' to false to enable it.');

                  case 3:
                    _context3.next = 5;
                    return this.ensureUserManagerInitialized();

                  case 5:
                    _context3.next = 7;
                    return this.userManager.signoutPopup(this.createArguments());

                  case 7:
                    this.userSubject.next(null);
                    return _context3.abrupt("return", this.success(state));

                  case 11:
                    _context3.prev = 11;
                    _context3.t0 = _context3["catch"](0);
                    console.log('Popup signout error: ', _context3.t0);
                    _context3.prev = 14;
                    _context3.next = 17;
                    return this.userManager.signoutRedirect(this.createArguments(state));

                  case 17:
                    return _context3.abrupt("return", this.redirect());

                  case 20:
                    _context3.prev = 20;
                    _context3.t1 = _context3["catch"](14);
                    console.log('Redirect signout error: ', _context3.t0);
                    return _context3.abrupt("return", this.error(_context3.t1));

                  case 24:
                  case "end":
                    return _context3.stop();
                }
              }
            }, _callee3, this, [[0, 11], [14, 20]]);
          }));
        }
      }, {
        key: "completeSignOut",
        value: function completeSignOut(url) {
          return Object(tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"])(this, void 0, void 0, /*#__PURE__*/regeneratorRuntime.mark(function _callee4() {
            var response;
            return regeneratorRuntime.wrap(function _callee4$(_context4) {
              while (1) {
                switch (_context4.prev = _context4.next) {
                  case 0:
                    _context4.next = 2;
                    return this.ensureUserManagerInitialized();

                  case 2:
                    _context4.prev = 2;
                    _context4.next = 5;
                    return this.userManager.signoutCallback(url);

                  case 5:
                    response = _context4.sent;
                    this.userSubject.next(null);
                    return _context4.abrupt("return", this.success(response && response.state));

                  case 10:
                    _context4.prev = 10;
                    _context4.t0 = _context4["catch"](2);
                    console.log("There was an error trying to log out '".concat(_context4.t0, "'."));
                    return _context4.abrupt("return", this.error(_context4.t0));

                  case 14:
                  case "end":
                    return _context4.stop();
                }
              }
            }, _callee4, this, [[2, 10]]);
          }));
        }
      }, {
        key: "createArguments",
        value: function createArguments(state) {
          return {
            useReplaceToNavigate: true,
            data: state
          };
        }
      }, {
        key: "error",
        value: function error(message) {
          return {
            status: AuthenticationResultStatus.Fail,
            message: message
          };
        }
      }, {
        key: "success",
        value: function success(state) {
          return {
            status: AuthenticationResultStatus.Success,
            state: state
          };
        }
      }, {
        key: "redirect",
        value: function redirect() {
          return {
            status: AuthenticationResultStatus.Redirect
          };
        }
      }, {
        key: "ensureUserManagerInitialized",
        value: function ensureUserManagerInitialized() {
          return Object(tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"])(this, void 0, void 0, /*#__PURE__*/regeneratorRuntime.mark(function _callee6() {
            var _this4 = this;

            var response, settings;
            return regeneratorRuntime.wrap(function _callee6$(_context6) {
              while (1) {
                switch (_context6.prev = _context6.next) {
                  case 0:
                    if (!(this.userManager !== undefined)) {
                      _context6.next = 2;
                      break;
                    }

                    return _context6.abrupt("return");

                  case 2:
                    _context6.next = 4;
                    return fetch(_api_authorization_constants__WEBPACK_IMPORTED_MODULE_5__["ApplicationPaths"].ApiAuthorizationClientConfigurationUrl);

                  case 4:
                    response = _context6.sent;

                    if (response.ok) {
                      _context6.next = 7;
                      break;
                    }

                    throw new Error("Could not load settings for '".concat(_api_authorization_constants__WEBPACK_IMPORTED_MODULE_5__["ApplicationName"], "'"));

                  case 7:
                    _context6.next = 9;
                    return response.json();

                  case 9:
                    settings = _context6.sent;
                    settings.automaticSilentRenew = true;
                    settings.includeIdTokenInSilentRenew = true;
                    this.userManager = new oidc_client__WEBPACK_IMPORTED_MODULE_2__["UserManager"](settings);
                    this.userManager.events.addUserSignedOut(function () {
                      return Object(tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"])(_this4, void 0, void 0, /*#__PURE__*/regeneratorRuntime.mark(function _callee5() {
                        return regeneratorRuntime.wrap(function _callee5$(_context5) {
                          while (1) {
                            switch (_context5.prev = _context5.next) {
                              case 0:
                                _context5.next = 2;
                                return this.userManager.removeUser();

                              case 2:
                                this.userSubject.next(null);

                              case 3:
                              case "end":
                                return _context5.stop();
                            }
                          }
                        }, _callee5, this);
                      }));
                    });

                  case 14:
                  case "end":
                    return _context6.stop();
                }
              }
            }, _callee6, this);
          }));
        }
      }, {
        key: "getUserFromStorage",
        value: function getUserFromStorage() {
          var _this5 = this;

          return Object(rxjs__WEBPACK_IMPORTED_MODULE_3__["from"])(this.ensureUserManagerInitialized()).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["mergeMap"])(function () {
            return _this5.userManager.getUser();
          }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["map"])(function (u) {
            return u && u.profile;
          }));
        }
      }]);

      return AuthorizeService;
    }();

    AuthorizeService.ɵfac = function AuthorizeService_Factory(t) {
      return new (t || AuthorizeService)();
    };

    AuthorizeService.ɵprov = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdefineInjectable"]({
      token: AuthorizeService,
      factory: AuthorizeService.ɵfac,
      providedIn: 'root'
    });
    /*@__PURE__*/

    (function () {
      _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵsetClassMetadata"](AuthorizeService, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"],
        args: [{
          providedIn: 'root'
        }]
      }], null, null);
    })();
    /***/

  },

  /***/
  "./src/app/api-authorization/login-menu/login-menu.component.ts":
  /*!**********************************************************************!*\
    !*** ./src/app/api-authorization/login-menu/login-menu.component.ts ***!
    \**********************************************************************/

  /*! exports provided: LoginMenuComponent */

  /***/
  function srcAppApiAuthorizationLoginMenuLoginMenuComponentTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "LoginMenuComponent", function () {
      return LoginMenuComponent;
    });
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
    /* harmony import */


    var rxjs_operators__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! rxjs/operators */
    "./node_modules/rxjs/_esm2015/operators/index.js");
    /* harmony import */


    var _authorize_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! ../authorize.service */
    "./src/app/api-authorization/authorize.service.ts");
    /* harmony import */


    var _angular_common__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
    /*! @angular/common */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/common.js");
    /* harmony import */


    var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(
    /*! @angular/router */
    "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");

    var _c0 = function _c0() {
      return ["/authentication/profile"];
    };

    var _c1 = function _c1() {
      return ["/authentication/logout"];
    };

    var _c2 = function _c2() {
      return {
        local: true
      };
    };

    function LoginMenuComponent_ul_0_Template(rf, ctx) {
      if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "ul", 1);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](1, "li", 2);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](2, "a", 3);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](3);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpipe"](4, "async");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](5, "li", 2);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](6, "a", 4);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](7, "Logout");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
      }

      if (rf & 2) {
        var ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵnextContext"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](2);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("routerLink", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpureFunction0"](6, _c0));

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtextInterpolate1"]("Hello ", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpipeBind1"](4, 4, ctx_r0.userName), "");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](3);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("routerLink", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpureFunction0"](7, _c1))("state", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpureFunction0"](8, _c2));
      }
    }

    var _c3 = function _c3() {
      return ["/authentication/register"];
    };

    var _c4 = function _c4() {
      return ["/authentication/login"];
    };

    function LoginMenuComponent_ul_2_Template(rf, ctx) {
      if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "ul", 1);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](1, "li", 2);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](2, "a", 5);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](3, "Register");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](4, "li", 2);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](5, "a", 5);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](6, "Login");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
      }

      if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](2);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("routerLink", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpureFunction0"](2, _c3));

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](3);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("routerLink", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpureFunction0"](3, _c4));
      }
    }

    var LoginMenuComponent = /*#__PURE__*/function () {
      function LoginMenuComponent(authorizeService) {
        _classCallCheck(this, LoginMenuComponent);

        this.authorizeService = authorizeService;
      }

      _createClass(LoginMenuComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {
          this.isAuthenticated = this.authorizeService.isAuthenticated();
          this.userName = this.authorizeService.getUser().pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["map"])(function (u) {
            return u && u.name;
          }));
        }
      }]);

      return LoginMenuComponent;
    }();

    LoginMenuComponent.ɵfac = function LoginMenuComponent_Factory(t) {
      return new (t || LoginMenuComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdirectiveInject"](_authorize_service__WEBPACK_IMPORTED_MODULE_2__["AuthorizeService"]));
    };

    LoginMenuComponent.ɵcmp = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineComponent"]({
      type: LoginMenuComponent,
      selectors: [["app-login-menu"]],
      decls: 4,
      vars: 6,
      consts: [["class", "navbar-nav", 4, "ngIf"], [1, "navbar-nav"], [1, "nav-item"], ["title", "Manage", 1, "nav-link", "text-dark", 3, "routerLink"], ["title", "Logout", 1, "nav-link", "text-dark", 3, "routerLink", "state"], [1, "nav-link", "text-dark", 3, "routerLink"]],
      template: function LoginMenuComponent_Template(rf, ctx) {
        if (rf & 1) {
          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](0, LoginMenuComponent_ul_0_Template, 8, 9, "ul", 0);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpipe"](1, "async");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](2, LoginMenuComponent_ul_2_Template, 7, 4, "ul", 0);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpipe"](3, "async");
        }

        if (rf & 2) {
          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpipeBind1"](1, 2, ctx.isAuthenticated));

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](2);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", !_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpipeBind1"](3, 4, ctx.isAuthenticated));
        }
      },
      directives: [_angular_common__WEBPACK_IMPORTED_MODULE_3__["NgIf"], _angular_router__WEBPACK_IMPORTED_MODULE_4__["RouterLinkWithHref"]],
      pipes: [_angular_common__WEBPACK_IMPORTED_MODULE_3__["AsyncPipe"]],
      styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2FwaS1hdXRob3JpemF0aW9uL2xvZ2luLW1lbnUvbG9naW4tbWVudS5jb21wb25lbnQuY3NzIn0= */"]
    });
    /*@__PURE__*/

    (function () {
      _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](LoginMenuComponent, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"],
        args: [{
          selector: 'app-login-menu',
          templateUrl: './login-menu.component.html',
          styleUrls: ['./login-menu.component.css']
        }]
      }], function () {
        return [{
          type: _authorize_service__WEBPACK_IMPORTED_MODULE_2__["AuthorizeService"]
        }];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/app/api-authorization/login/login.component.ts":
  /*!************************************************************!*\
    !*** ./src/app/api-authorization/login/login.component.ts ***!
    \************************************************************/

  /*! exports provided: LoginComponent */

  /***/
  function srcAppApiAuthorizationLoginLoginComponentTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "LoginComponent", function () {
      return LoginComponent;
    });
    /* harmony import */


    var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! tslib */
    "./node_modules/tslib/tslib.es6.js");
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
    /* harmony import */


    var _authorize_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! ../authorize.service */
    "./src/app/api-authorization/authorize.service.ts");
    /* harmony import */


    var rxjs__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
    /*! rxjs */
    "./node_modules/rxjs/_esm2015/index.js");
    /* harmony import */


    var _api_authorization_constants__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(
    /*! ../api-authorization.constants */
    "./src/app/api-authorization/api-authorization.constants.ts");
    /* harmony import */


    var _angular_router__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(
    /*! @angular/router */
    "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");
    /* harmony import */


    var _angular_common__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(
    /*! @angular/common */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/common.js"); // The main responsibility of this component is to handle the user's login process.
    // This is the starting point for the login process. Any component that needs to authenticate
    // a user can simply perform a redirect to this component with a returnUrl query parameter and
    // let the component perform the login and return back to the return url.


    var LoginComponent = /*#__PURE__*/function () {
      function LoginComponent(authorizeService, activatedRoute, router) {
        _classCallCheck(this, LoginComponent);

        this.authorizeService = authorizeService;
        this.activatedRoute = activatedRoute;
        this.router = router;
        this.message = new rxjs__WEBPACK_IMPORTED_MODULE_3__["BehaviorSubject"](null);
      }

      _createClass(LoginComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {
          return Object(tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"])(this, void 0, void 0, /*#__PURE__*/regeneratorRuntime.mark(function _callee7() {
            var action, message;
            return regeneratorRuntime.wrap(function _callee7$(_context7) {
              while (1) {
                switch (_context7.prev = _context7.next) {
                  case 0:
                    action = this.activatedRoute.snapshot.url[1];
                    _context7.t0 = action.path;
                    _context7.next = _context7.t0 === _api_authorization_constants__WEBPACK_IMPORTED_MODULE_4__["LoginActions"].Login ? 4 : _context7.t0 === _api_authorization_constants__WEBPACK_IMPORTED_MODULE_4__["LoginActions"].LoginCallback ? 7 : _context7.t0 === _api_authorization_constants__WEBPACK_IMPORTED_MODULE_4__["LoginActions"].LoginFailed ? 10 : _context7.t0 === _api_authorization_constants__WEBPACK_IMPORTED_MODULE_4__["LoginActions"].Profile ? 13 : _context7.t0 === _api_authorization_constants__WEBPACK_IMPORTED_MODULE_4__["LoginActions"].Register ? 15 : 17;
                    break;

                  case 4:
                    _context7.next = 6;
                    return this.login(this.getReturnUrl());

                  case 6:
                    return _context7.abrupt("break", 18);

                  case 7:
                    _context7.next = 9;
                    return this.processLoginCallback();

                  case 9:
                    return _context7.abrupt("break", 18);

                  case 10:
                    message = this.activatedRoute.snapshot.queryParamMap.get(_api_authorization_constants__WEBPACK_IMPORTED_MODULE_4__["QueryParameterNames"].Message);
                    this.message.next(message);
                    return _context7.abrupt("break", 18);

                  case 13:
                    this.redirectToProfile();
                    return _context7.abrupt("break", 18);

                  case 15:
                    this.redirectToRegister();
                    return _context7.abrupt("break", 18);

                  case 17:
                    throw new Error("Invalid action '".concat(action, "'"));

                  case 18:
                  case "end":
                    return _context7.stop();
                }
              }
            }, _callee7, this);
          }));
        }
      }, {
        key: "login",
        value: function login(returnUrl) {
          return Object(tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"])(this, void 0, void 0, /*#__PURE__*/regeneratorRuntime.mark(function _callee8() {
            var state, result;
            return regeneratorRuntime.wrap(function _callee8$(_context8) {
              while (1) {
                switch (_context8.prev = _context8.next) {
                  case 0:
                    state = {
                      returnUrl: returnUrl
                    };
                    _context8.next = 3;
                    return this.authorizeService.signIn(state);

                  case 3:
                    result = _context8.sent;
                    this.message.next(undefined);
                    _context8.t0 = result.status;
                    _context8.next = _context8.t0 === _authorize_service__WEBPACK_IMPORTED_MODULE_2__["AuthenticationResultStatus"].Redirect ? 8 : _context8.t0 === _authorize_service__WEBPACK_IMPORTED_MODULE_2__["AuthenticationResultStatus"].Success ? 9 : _context8.t0 === _authorize_service__WEBPACK_IMPORTED_MODULE_2__["AuthenticationResultStatus"].Fail ? 12 : 15;
                    break;

                  case 8:
                    return _context8.abrupt("break", 16);

                  case 9:
                    _context8.next = 11;
                    return this.navigateToReturnUrl(returnUrl);

                  case 11:
                    return _context8.abrupt("break", 16);

                  case 12:
                    _context8.next = 14;
                    return this.router.navigate(_api_authorization_constants__WEBPACK_IMPORTED_MODULE_4__["ApplicationPaths"].LoginFailedPathComponents, {
                      queryParams: _defineProperty({}, _api_authorization_constants__WEBPACK_IMPORTED_MODULE_4__["QueryParameterNames"].Message, result.message)
                    });

                  case 14:
                    return _context8.abrupt("break", 16);

                  case 15:
                    throw new Error("Invalid status result ".concat(result.status, "."));

                  case 16:
                  case "end":
                    return _context8.stop();
                }
              }
            }, _callee8, this);
          }));
        }
      }, {
        key: "processLoginCallback",
        value: function processLoginCallback() {
          return Object(tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"])(this, void 0, void 0, /*#__PURE__*/regeneratorRuntime.mark(function _callee9() {
            var url, result;
            return regeneratorRuntime.wrap(function _callee9$(_context9) {
              while (1) {
                switch (_context9.prev = _context9.next) {
                  case 0:
                    url = window.location.href;
                    _context9.next = 3;
                    return this.authorizeService.completeSignIn(url);

                  case 3:
                    result = _context9.sent;
                    _context9.t0 = result.status;
                    _context9.next = _context9.t0 === _authorize_service__WEBPACK_IMPORTED_MODULE_2__["AuthenticationResultStatus"].Redirect ? 7 : _context9.t0 === _authorize_service__WEBPACK_IMPORTED_MODULE_2__["AuthenticationResultStatus"].Success ? 8 : _context9.t0 === _authorize_service__WEBPACK_IMPORTED_MODULE_2__["AuthenticationResultStatus"].Fail ? 11 : 13;
                    break;

                  case 7:
                    throw new Error('Should not redirect.');

                  case 8:
                    _context9.next = 10;
                    return this.navigateToReturnUrl(this.getReturnUrl(result.state));

                  case 10:
                    return _context9.abrupt("break", 13);

                  case 11:
                    this.message.next(result.message);
                    return _context9.abrupt("break", 13);

                  case 13:
                  case "end":
                    return _context9.stop();
                }
              }
            }, _callee9, this);
          }));
        }
      }, {
        key: "redirectToRegister",
        value: function redirectToRegister() {
          this.redirectToApiAuthorizationPath("".concat(_api_authorization_constants__WEBPACK_IMPORTED_MODULE_4__["ApplicationPaths"].IdentityRegisterPath, "?returnUrl=").concat(encodeURI('/' + _api_authorization_constants__WEBPACK_IMPORTED_MODULE_4__["ApplicationPaths"].Login)));
        }
      }, {
        key: "redirectToProfile",
        value: function redirectToProfile() {
          this.redirectToApiAuthorizationPath(_api_authorization_constants__WEBPACK_IMPORTED_MODULE_4__["ApplicationPaths"].IdentityManagePath);
        }
      }, {
        key: "navigateToReturnUrl",
        value: function navigateToReturnUrl(returnUrl) {
          return Object(tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"])(this, void 0, void 0, /*#__PURE__*/regeneratorRuntime.mark(function _callee10() {
            return regeneratorRuntime.wrap(function _callee10$(_context10) {
              while (1) {
                switch (_context10.prev = _context10.next) {
                  case 0:
                    _context10.next = 2;
                    return this.router.navigateByUrl(returnUrl, {
                      replaceUrl: true
                    });

                  case 2:
                  case "end":
                    return _context10.stop();
                }
              }
            }, _callee10, this);
          }));
        }
      }, {
        key: "getReturnUrl",
        value: function getReturnUrl(state) {
          var fromQuery = this.activatedRoute.snapshot.queryParams.returnUrl; // If the url is comming from the query string, check that is either
          // a relative url or an absolute url

          if (fromQuery && !(fromQuery.startsWith("".concat(window.location.origin, "/")) || /\/[^\/].*/.test(fromQuery))) {
            // This is an extra check to prevent open redirects.
            throw new Error('Invalid return url. The return url needs to have the same origin as the current page.');
          }

          return state && state.returnUrl || fromQuery || _api_authorization_constants__WEBPACK_IMPORTED_MODULE_4__["ApplicationPaths"].DefaultLoginRedirectPath;
        }
      }, {
        key: "redirectToApiAuthorizationPath",
        value: function redirectToApiAuthorizationPath(apiAuthorizationPath) {
          // It's important that we do a replace here so that when the user hits the back arrow on the
          // browser they get sent back to where it was on the app instead of to an endpoint on this
          // component.
          //const redirectUrl = `${window.location.origin}${apiAuthorizationPath}`;
          var redirectUrl = apiAuthorizationPath;
          window.location.replace(redirectUrl);
        }
      }]);

      return LoginComponent;
    }();

    LoginComponent.ɵfac = function LoginComponent_Factory(t) {
      return new (t || LoginComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdirectiveInject"](_authorize_service__WEBPACK_IMPORTED_MODULE_2__["AuthorizeService"]), _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_5__["ActivatedRoute"]), _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_5__["Router"]));
    };

    LoginComponent.ɵcmp = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdefineComponent"]({
      type: LoginComponent,
      selectors: [["app-login"]],
      decls: 3,
      vars: 3,
      template: function LoginComponent_Template(rf, ctx) {
        if (rf & 1) {
          _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "p");

          _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtext"](1);

          _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵpipe"](2, "async");

          _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
        }

        if (rf & 2) {
          _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);

          _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtextInterpolate"](_angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵpipeBind1"](2, 1, ctx.message));
        }
      },
      pipes: [_angular_common__WEBPACK_IMPORTED_MODULE_6__["AsyncPipe"]],
      styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2FwaS1hdXRob3JpemF0aW9uL2xvZ2luL2xvZ2luLmNvbXBvbmVudC5jc3MifQ== */"]
    });
    /*@__PURE__*/

    (function () {
      _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵsetClassMetadata"](LoginComponent, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"],
        args: [{
          selector: 'app-login',
          templateUrl: './login.component.html',
          styleUrls: ['./login.component.css']
        }]
      }], function () {
        return [{
          type: _authorize_service__WEBPACK_IMPORTED_MODULE_2__["AuthorizeService"]
        }, {
          type: _angular_router__WEBPACK_IMPORTED_MODULE_5__["ActivatedRoute"]
        }, {
          type: _angular_router__WEBPACK_IMPORTED_MODULE_5__["Router"]
        }];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/app/api-authorization/logout/logout.component.ts":
  /*!**************************************************************!*\
    !*** ./src/app/api-authorization/logout/logout.component.ts ***!
    \**************************************************************/

  /*! exports provided: LogoutComponent */

  /***/
  function srcAppApiAuthorizationLogoutLogoutComponentTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "LogoutComponent", function () {
      return LogoutComponent;
    });
    /* harmony import */


    var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! tslib */
    "./node_modules/tslib/tslib.es6.js");
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
    /* harmony import */


    var _authorize_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! ../authorize.service */
    "./src/app/api-authorization/authorize.service.ts");
    /* harmony import */


    var rxjs__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
    /*! rxjs */
    "./node_modules/rxjs/_esm2015/index.js");
    /* harmony import */


    var rxjs_operators__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(
    /*! rxjs/operators */
    "./node_modules/rxjs/_esm2015/operators/index.js");
    /* harmony import */


    var _api_authorization_constants__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(
    /*! ../api-authorization.constants */
    "./src/app/api-authorization/api-authorization.constants.ts");
    /* harmony import */


    var _angular_router__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(
    /*! @angular/router */
    "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");
    /* harmony import */


    var _angular_common__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(
    /*! @angular/common */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/common.js"); // The main responsibility of this component is to handle the user's logout process.
    // This is the starting point for the logout process, which is usually initiated when a
    // user clicks on the logout button on the LoginMenu component.


    var LogoutComponent = /*#__PURE__*/function () {
      function LogoutComponent(authorizeService, activatedRoute, router) {
        _classCallCheck(this, LogoutComponent);

        this.authorizeService = authorizeService;
        this.activatedRoute = activatedRoute;
        this.router = router;
        this.message = new rxjs__WEBPACK_IMPORTED_MODULE_3__["BehaviorSubject"](null);
      }

      _createClass(LogoutComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {
          return Object(tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"])(this, void 0, void 0, /*#__PURE__*/regeneratorRuntime.mark(function _callee11() {
            var action;
            return regeneratorRuntime.wrap(function _callee11$(_context11) {
              while (1) {
                switch (_context11.prev = _context11.next) {
                  case 0:
                    action = this.activatedRoute.snapshot.url[1];
                    _context11.t0 = action.path;
                    _context11.next = _context11.t0 === _api_authorization_constants__WEBPACK_IMPORTED_MODULE_5__["LogoutActions"].Logout ? 4 : _context11.t0 === _api_authorization_constants__WEBPACK_IMPORTED_MODULE_5__["LogoutActions"].LogoutCallback ? 11 : _context11.t0 === _api_authorization_constants__WEBPACK_IMPORTED_MODULE_5__["LogoutActions"].LoggedOut ? 14 : 16;
                    break;

                  case 4:
                    if (!window.history.state.local) {
                      _context11.next = 9;
                      break;
                    }

                    _context11.next = 7;
                    return this.logout(this.getReturnUrl());

                  case 7:
                    _context11.next = 10;
                    break;

                  case 9:
                    // This prevents regular links to <app>/authentication/logout from triggering a logout
                    this.message.next('The logout was not initiated from within the page.');

                  case 10:
                    return _context11.abrupt("break", 17);

                  case 11:
                    _context11.next = 13;
                    return this.processLogoutCallback();

                  case 13:
                    return _context11.abrupt("break", 17);

                  case 14:
                    this.message.next('You successfully logged out!');
                    return _context11.abrupt("break", 17);

                  case 16:
                    throw new Error("Invalid action '".concat(action, "'"));

                  case 17:
                  case "end":
                    return _context11.stop();
                }
              }
            }, _callee11, this);
          }));
        }
      }, {
        key: "logout",
        value: function logout(returnUrl) {
          return Object(tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"])(this, void 0, void 0, /*#__PURE__*/regeneratorRuntime.mark(function _callee12() {
            var state, isauthenticated, result;
            return regeneratorRuntime.wrap(function _callee12$(_context12) {
              while (1) {
                switch (_context12.prev = _context12.next) {
                  case 0:
                    state = {
                      returnUrl: returnUrl
                    };
                    _context12.next = 3;
                    return this.authorizeService.isAuthenticated().pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["take"])(1)).toPromise();

                  case 3:
                    isauthenticated = _context12.sent;

                    if (!isauthenticated) {
                      _context12.next = 20;
                      break;
                    }

                    _context12.next = 7;
                    return this.authorizeService.signOut(state);

                  case 7:
                    result = _context12.sent;
                    _context12.t0 = result.status;
                    _context12.next = _context12.t0 === _authorize_service__WEBPACK_IMPORTED_MODULE_2__["AuthenticationResultStatus"].Redirect ? 11 : _context12.t0 === _authorize_service__WEBPACK_IMPORTED_MODULE_2__["AuthenticationResultStatus"].Success ? 12 : _context12.t0 === _authorize_service__WEBPACK_IMPORTED_MODULE_2__["AuthenticationResultStatus"].Fail ? 15 : 17;
                    break;

                  case 11:
                    return _context12.abrupt("break", 18);

                  case 12:
                    _context12.next = 14;
                    return this.navigateToReturnUrl(returnUrl);

                  case 14:
                    return _context12.abrupt("break", 18);

                  case 15:
                    this.message.next(result.message);
                    return _context12.abrupt("break", 18);

                  case 17:
                    throw new Error('Invalid authentication result status.');

                  case 18:
                    _context12.next = 21;
                    break;

                  case 20:
                    this.message.next('You successfully logged out!');

                  case 21:
                  case "end":
                    return _context12.stop();
                }
              }
            }, _callee12, this);
          }));
        }
      }, {
        key: "processLogoutCallback",
        value: function processLogoutCallback() {
          return Object(tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"])(this, void 0, void 0, /*#__PURE__*/regeneratorRuntime.mark(function _callee13() {
            var url, result;
            return regeneratorRuntime.wrap(function _callee13$(_context13) {
              while (1) {
                switch (_context13.prev = _context13.next) {
                  case 0:
                    url = window.location.href;
                    _context13.next = 3;
                    return this.authorizeService.completeSignOut(url);

                  case 3:
                    result = _context13.sent;
                    _context13.t0 = result.status;
                    _context13.next = _context13.t0 === _authorize_service__WEBPACK_IMPORTED_MODULE_2__["AuthenticationResultStatus"].Redirect ? 7 : _context13.t0 === _authorize_service__WEBPACK_IMPORTED_MODULE_2__["AuthenticationResultStatus"].Success ? 8 : _context13.t0 === _authorize_service__WEBPACK_IMPORTED_MODULE_2__["AuthenticationResultStatus"].Fail ? 11 : 13;
                    break;

                  case 7:
                    throw new Error('Should not redirect.');

                  case 8:
                    _context13.next = 10;
                    return this.navigateToReturnUrl(this.getReturnUrl(result.state));

                  case 10:
                    return _context13.abrupt("break", 14);

                  case 11:
                    this.message.next(result.message);
                    return _context13.abrupt("break", 14);

                  case 13:
                    throw new Error('Invalid authentication result status.');

                  case 14:
                  case "end":
                    return _context13.stop();
                }
              }
            }, _callee13, this);
          }));
        }
      }, {
        key: "navigateToReturnUrl",
        value: function navigateToReturnUrl(returnUrl) {
          return Object(tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"])(this, void 0, void 0, /*#__PURE__*/regeneratorRuntime.mark(function _callee14() {
            return regeneratorRuntime.wrap(function _callee14$(_context14) {
              while (1) {
                switch (_context14.prev = _context14.next) {
                  case 0:
                    _context14.next = 2;
                    return this.router.navigateByUrl(returnUrl, {
                      replaceUrl: true
                    });

                  case 2:
                  case "end":
                    return _context14.stop();
                }
              }
            }, _callee14, this);
          }));
        }
      }, {
        key: "getReturnUrl",
        value: function getReturnUrl(state) {
          var fromQuery = this.activatedRoute.snapshot.queryParams.returnUrl; // If the url is comming from the query string, check that is either
          // a relative url or an absolute url

          if (fromQuery && !(fromQuery.startsWith("".concat(window.location.origin, "/")) || /\/[^\/].*/.test(fromQuery))) {
            // This is an extra check to prevent open redirects.
            throw new Error('Invalid return url. The return url needs to have the same origin as the current page.');
          }

          return state && state.returnUrl || fromQuery || _api_authorization_constants__WEBPACK_IMPORTED_MODULE_5__["ApplicationPaths"].LoggedOut;
        }
      }]);

      return LogoutComponent;
    }();

    LogoutComponent.ɵfac = function LogoutComponent_Factory(t) {
      return new (t || LogoutComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdirectiveInject"](_authorize_service__WEBPACK_IMPORTED_MODULE_2__["AuthorizeService"]), _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_6__["ActivatedRoute"]), _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_6__["Router"]));
    };

    LogoutComponent.ɵcmp = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdefineComponent"]({
      type: LogoutComponent,
      selectors: [["app-logout"]],
      decls: 3,
      vars: 3,
      template: function LogoutComponent_Template(rf, ctx) {
        if (rf & 1) {
          _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "p");

          _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtext"](1);

          _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵpipe"](2, "async");

          _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
        }

        if (rf & 2) {
          _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);

          _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtextInterpolate"](_angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵpipeBind1"](2, 1, ctx.message));
        }
      },
      pipes: [_angular_common__WEBPACK_IMPORTED_MODULE_7__["AsyncPipe"]],
      styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2FwaS1hdXRob3JpemF0aW9uL2xvZ291dC9sb2dvdXQuY29tcG9uZW50LmNzcyJ9 */"]
    });
    /*@__PURE__*/

    (function () {
      _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵsetClassMetadata"](LogoutComponent, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"],
        args: [{
          selector: 'app-logout',
          templateUrl: './logout.component.html',
          styleUrls: ['./logout.component.css']
        }]
      }], function () {
        return [{
          type: _authorize_service__WEBPACK_IMPORTED_MODULE_2__["AuthorizeService"]
        }, {
          type: _angular_router__WEBPACK_IMPORTED_MODULE_6__["ActivatedRoute"]
        }, {
          type: _angular_router__WEBPACK_IMPORTED_MODULE_6__["Router"]
        }];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/app/app-routing.module.ts":
  /*!***************************************!*\
    !*** ./src/app/app-routing.module.ts ***!
    \***************************************/

  /*! exports provided: AppRoutingModule */

  /***/
  function srcAppAppRoutingModuleTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "AppRoutingModule", function () {
      return AppRoutingModule;
    });
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
    /* harmony import */


    var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/router */
    "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");
    /* harmony import */


    var _home_home_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! ./home/home.component */
    "./src/app/home/home.component.ts");
    /* harmony import */


    var _post_details_post_details_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
    /*! ./post-details/post-details.component */
    "./src/app/post-details/post-details.component.ts");
    /* harmony import */


    var _stock_stock_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(
    /*! ./stock/stock.component */
    "./src/app/stock/stock.component.ts");
    /* harmony import */


    var _user_user_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(
    /*! ./user/user.component */
    "./src/app/user/user.component.ts");
    /* harmony import */


    var _tag_tag_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(
    /*! ./tag/tag.component */
    "./src/app/tag/tag.component.ts");

    var routes = [{
      path: '',
      component: _home_home_component__WEBPACK_IMPORTED_MODULE_2__["HomeComponent"],
      pathMatch: 'full'
    }, {
      path: 'post/:postId',
      component: _post_details_post_details_component__WEBPACK_IMPORTED_MODULE_3__["PostDetailsComponent"]
    }, {
      path: 'stock/:symbol',
      component: _stock_stock_component__WEBPACK_IMPORTED_MODULE_4__["StockComponent"]
    }, {
      path: 'user/:username',
      component: _user_user_component__WEBPACK_IMPORTED_MODULE_5__["UserComponent"]
    }, {
      path: 'tag/:tag',
      component: _tag_tag_component__WEBPACK_IMPORTED_MODULE_6__["TagComponent"]
    }];

    var AppRoutingModule = function AppRoutingModule() {
      _classCallCheck(this, AppRoutingModule);
    };

    AppRoutingModule.ɵmod = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineNgModule"]({
      type: AppRoutingModule
    });
    AppRoutingModule.ɵinj = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineInjector"]({
      factory: function AppRoutingModule_Factory(t) {
        return new (t || AppRoutingModule)();
      },
      imports: [[_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"].forRoot(routes)], _angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"]]
    });

    (function () {
      (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵsetNgModuleScope"](AppRoutingModule, {
        imports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"]],
        exports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"]]
      });
    })();
    /*@__PURE__*/


    (function () {
      _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](AppRoutingModule, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"],
        args: [{
          imports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"].forRoot(routes)],
          exports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"]]
        }]
      }], null, null);
    })();
    /***/

  },

  /***/
  "./src/app/app.component.ts":
  /*!**********************************!*\
    !*** ./src/app/app.component.ts ***!
    \**********************************/

  /*! exports provided: AppComponent */

  /***/
  function srcAppAppComponentTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "AppComponent", function () {
      return AppComponent;
    });
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
    /* harmony import */


    var _angular_material_icon__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/material/icon */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/icon.js");
    /* harmony import */


    var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! @angular/platform-browser */
    "./node_modules/@angular/platform-browser/__ivy_ngcc__/fesm2015/platform-browser.js");
    /* harmony import */


    var _nav_menu_nav_menu_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
    /*! ./nav-menu/nav-menu.component */
    "./src/app/nav-menu/nav-menu.component.ts");
    /* harmony import */


    var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(
    /*! @angular/router */
    "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");

    var AppComponent = function AppComponent(iconRegistry, domSanitizer) {
      _classCallCheck(this, AppComponent);

      this.iconRegistry = iconRegistry;
      this.domSanitizer = domSanitizer;
      this.title = 'Client';
      this.iconRegistry.addSvgIcon('bearish', this.domSanitizer.bypassSecurityTrustResourceUrl('./assets/bear.svg'));
      this.iconRegistry.addSvgIcon('bullish', this.domSanitizer.bypassSecurityTrustResourceUrl('./assets/bull-face.svg'));
      this.iconRegistry.addSvgIcon('like', this.domSanitizer.bypassSecurityTrustResourceUrl('./assets/like.svg'));
    };

    AppComponent.ɵfac = function AppComponent_Factory(t) {
      return new (t || AppComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdirectiveInject"](_angular_material_icon__WEBPACK_IMPORTED_MODULE_1__["MatIconRegistry"]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdirectiveInject"](_angular_platform_browser__WEBPACK_IMPORTED_MODULE_2__["DomSanitizer"]));
    };

    AppComponent.ɵcmp = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineComponent"]({
      type: AppComponent,
      selectors: [["app-root"]],
      decls: 4,
      vars: 0,
      consts: [[1, "container"]],
      template: function AppComponent_Template(rf, ctx) {
        if (rf & 1) {
          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "body");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](1, "app-nav-menu");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](2, "div", 0);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](3, "router-outlet");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        }
      },
      directives: [_nav_menu_nav_menu_component__WEBPACK_IMPORTED_MODULE_3__["NavMenuComponent"], _angular_router__WEBPACK_IMPORTED_MODULE_4__["RouterOutlet"]],
      styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2FwcC5jb21wb25lbnQuY3NzIn0= */"]
    });
    /*@__PURE__*/

    (function () {
      _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](AppComponent, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"],
        args: [{
          selector: 'app-root',
          templateUrl: './app.component.html',
          styleUrls: ['./app.component.css']
        }]
      }], function () {
        return [{
          type: _angular_material_icon__WEBPACK_IMPORTED_MODULE_1__["MatIconRegistry"]
        }, {
          type: _angular_platform_browser__WEBPACK_IMPORTED_MODULE_2__["DomSanitizer"]
        }];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/app/app.module.ts":
  /*!*******************************!*\
    !*** ./src/app/app.module.ts ***!
    \*******************************/

  /*! exports provided: AppModule */

  /***/
  function srcAppAppModuleTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "AppModule", function () {
      return AppModule;
    });
    /* harmony import */


    var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! @angular/platform-browser */
    "./node_modules/@angular/platform-browser/__ivy_ngcc__/fesm2015/platform-browser.js");
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
    /* harmony import */


    var _app_routing_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! ./app-routing.module */
    "./src/app/app-routing.module.ts");
    /* harmony import */


    var _app_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
    /*! ./app.component */
    "./src/app/app.component.ts");
    /* harmony import */


    var _nav_menu_nav_menu_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(
    /*! ./nav-menu/nav-menu.component */
    "./src/app/nav-menu/nav-menu.component.ts");
    /* harmony import */


    var _home_home_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(
    /*! ./home/home.component */
    "./src/app/home/home.component.ts");
    /* harmony import */


    var _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(
    /*! @angular/platform-browser/animations */
    "./node_modules/@angular/platform-browser/__ivy_ngcc__/fesm2015/animations.js");
    /* harmony import */


    var _ngmaterial_ngmaterial_module__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(
    /*! ./ngmaterial/ngmaterial.module */
    "./src/app/ngmaterial/ngmaterial.module.ts");
    /* harmony import */


    var _watchlist_watchlist_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(
    /*! ./watchlist/watchlist.component */
    "./src/app/watchlist/watchlist.component.ts");
    /* harmony import */


    var _watchlist_watchlist_service__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(
    /*! ./watchlist/watchlist.service */
    "./src/app/watchlist/watchlist.service.ts");
    /* harmony import */


    var _angular_common_http__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(
    /*! @angular/common/http */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/http.js");
    /* harmony import */


    var _submit_post_form_submit_post_form_component__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(
    /*! ./submit-post-form/submit-post-form.component */
    "./src/app/submit-post-form/submit-post-form.component.ts");
    /* harmony import */


    var _feed_container_feed_container_component__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(
    /*! ./feed-container/feed-container.component */
    "./src/app/feed-container/feed-container.component.ts");
    /* harmony import */


    var _my_feed_my_feed_component__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(
    /*! ./my-feed/my-feed.component */
    "./src/app/my-feed/my-feed.component.ts");
    /* harmony import */


    var _my_feed_my_feed_service__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(
    /*! ./my-feed/my-feed.service */
    "./src/app/my-feed/my-feed.service.ts");
    /* harmony import */


    var _news_feed_news_feed_component__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(
    /*! ./news-feed/news-feed.component */
    "./src/app/news-feed/news-feed.component.ts");
    /* harmony import */


    var _pipes_linkify_pipe__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(
    /*! ./pipes/linkify-pipe */
    "./src/app/pipes/linkify-pipe.ts");
    /* harmony import */


    var _post_details_post_details_component__WEBPACK_IMPORTED_MODULE_17__ = __webpack_require__(
    /*! ./post-details/post-details.component */
    "./src/app/post-details/post-details.component.ts");
    /* harmony import */


    var _stock_stock_component__WEBPACK_IMPORTED_MODULE_18__ = __webpack_require__(
    /*! ./stock/stock.component */
    "./src/app/stock/stock.component.ts");
    /* harmony import */


    var _user_user_component__WEBPACK_IMPORTED_MODULE_19__ = __webpack_require__(
    /*! ./user/user.component */
    "./src/app/user/user.component.ts");
    /* harmony import */


    var _tag_tag_component__WEBPACK_IMPORTED_MODULE_20__ = __webpack_require__(
    /*! ./tag/tag.component */
    "./src/app/tag/tag.component.ts");
    /* harmony import */


    var _pipes_stirp_html_pipe__WEBPACK_IMPORTED_MODULE_21__ = __webpack_require__(
    /*! ./pipes/stirp-html-pipe */
    "./src/app/pipes/stirp-html-pipe.ts");
    /* harmony import */


    var _api_authorization_api_authorization_module__WEBPACK_IMPORTED_MODULE_22__ = __webpack_require__(
    /*! ./api-authorization/api-authorization.module */
    "./src/app/api-authorization/api-authorization.module.ts");
    /* harmony import */


    var _api_authorization_authorize_interceptor__WEBPACK_IMPORTED_MODULE_23__ = __webpack_require__(
    /*! ./api-authorization/authorize.interceptor */
    "./src/app/api-authorization/authorize.interceptor.ts");

    var AppModule = function AppModule() {
      _classCallCheck(this, AppModule);
    };

    AppModule.ɵmod = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdefineNgModule"]({
      type: AppModule,
      bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_3__["AppComponent"]]
    });
    AppModule.ɵinj = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdefineInjector"]({
      factory: function AppModule_Factory(t) {
        return new (t || AppModule)();
      },
      providers: [_watchlist_watchlist_service__WEBPACK_IMPORTED_MODULE_9__["WatchlistService"], _my_feed_my_feed_service__WEBPACK_IMPORTED_MODULE_14__["MyFeedService"], {
        provide: _angular_common_http__WEBPACK_IMPORTED_MODULE_10__["HTTP_INTERCEPTORS"],
        useClass: _api_authorization_authorize_interceptor__WEBPACK_IMPORTED_MODULE_23__["AuthorizeInterceptor"],
        multi: true
      }],
      imports: [[_angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__["BrowserModule"], _angular_common_http__WEBPACK_IMPORTED_MODULE_10__["HttpClientModule"], _api_authorization_api_authorization_module__WEBPACK_IMPORTED_MODULE_22__["ApiAuthorizationModule"], _app_routing_module__WEBPACK_IMPORTED_MODULE_2__["AppRoutingModule"], _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_6__["BrowserAnimationsModule"], _ngmaterial_ngmaterial_module__WEBPACK_IMPORTED_MODULE_7__["NgMaterialModule"]]]
    });

    (function () {
      (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵsetNgModuleScope"](AppModule, {
        declarations: [_app_component__WEBPACK_IMPORTED_MODULE_3__["AppComponent"], _nav_menu_nav_menu_component__WEBPACK_IMPORTED_MODULE_4__["NavMenuComponent"], _home_home_component__WEBPACK_IMPORTED_MODULE_5__["HomeComponent"], _watchlist_watchlist_component__WEBPACK_IMPORTED_MODULE_8__["WatchlistComponent"], _submit_post_form_submit_post_form_component__WEBPACK_IMPORTED_MODULE_11__["SubmitPostFormComponent"], _feed_container_feed_container_component__WEBPACK_IMPORTED_MODULE_12__["FeedContainerComponent"], _my_feed_my_feed_component__WEBPACK_IMPORTED_MODULE_13__["MyFeedComponent"], _news_feed_news_feed_component__WEBPACK_IMPORTED_MODULE_15__["NewsFeedComponent"], _pipes_linkify_pipe__WEBPACK_IMPORTED_MODULE_16__["LinkifyPipe"], _pipes_stirp_html_pipe__WEBPACK_IMPORTED_MODULE_21__["StripHtmlPipe"], _post_details_post_details_component__WEBPACK_IMPORTED_MODULE_17__["PostDetailsComponent"], _stock_stock_component__WEBPACK_IMPORTED_MODULE_18__["StockComponent"], _user_user_component__WEBPACK_IMPORTED_MODULE_19__["UserComponent"], _tag_tag_component__WEBPACK_IMPORTED_MODULE_20__["TagComponent"]],
        imports: [_angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__["BrowserModule"], _angular_common_http__WEBPACK_IMPORTED_MODULE_10__["HttpClientModule"], _api_authorization_api_authorization_module__WEBPACK_IMPORTED_MODULE_22__["ApiAuthorizationModule"], _app_routing_module__WEBPACK_IMPORTED_MODULE_2__["AppRoutingModule"], _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_6__["BrowserAnimationsModule"], _ngmaterial_ngmaterial_module__WEBPACK_IMPORTED_MODULE_7__["NgMaterialModule"]]
      });
    })();
    /*@__PURE__*/


    (function () {
      _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵsetClassMetadata"](AppModule, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"],
        args: [{
          declarations: [_app_component__WEBPACK_IMPORTED_MODULE_3__["AppComponent"], _nav_menu_nav_menu_component__WEBPACK_IMPORTED_MODULE_4__["NavMenuComponent"], _home_home_component__WEBPACK_IMPORTED_MODULE_5__["HomeComponent"], _watchlist_watchlist_component__WEBPACK_IMPORTED_MODULE_8__["WatchlistComponent"], _submit_post_form_submit_post_form_component__WEBPACK_IMPORTED_MODULE_11__["SubmitPostFormComponent"], _feed_container_feed_container_component__WEBPACK_IMPORTED_MODULE_12__["FeedContainerComponent"], _my_feed_my_feed_component__WEBPACK_IMPORTED_MODULE_13__["MyFeedComponent"], _news_feed_news_feed_component__WEBPACK_IMPORTED_MODULE_15__["NewsFeedComponent"], _pipes_linkify_pipe__WEBPACK_IMPORTED_MODULE_16__["LinkifyPipe"], _pipes_stirp_html_pipe__WEBPACK_IMPORTED_MODULE_21__["StripHtmlPipe"], _post_details_post_details_component__WEBPACK_IMPORTED_MODULE_17__["PostDetailsComponent"], _stock_stock_component__WEBPACK_IMPORTED_MODULE_18__["StockComponent"], _user_user_component__WEBPACK_IMPORTED_MODULE_19__["UserComponent"], _tag_tag_component__WEBPACK_IMPORTED_MODULE_20__["TagComponent"]],
          imports: [_angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__["BrowserModule"], _angular_common_http__WEBPACK_IMPORTED_MODULE_10__["HttpClientModule"], _api_authorization_api_authorization_module__WEBPACK_IMPORTED_MODULE_22__["ApiAuthorizationModule"], _app_routing_module__WEBPACK_IMPORTED_MODULE_2__["AppRoutingModule"], _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_6__["BrowserAnimationsModule"], _ngmaterial_ngmaterial_module__WEBPACK_IMPORTED_MODULE_7__["NgMaterialModule"]],
          providers: [_watchlist_watchlist_service__WEBPACK_IMPORTED_MODULE_9__["WatchlistService"], _my_feed_my_feed_service__WEBPACK_IMPORTED_MODULE_14__["MyFeedService"], {
            provide: _angular_common_http__WEBPACK_IMPORTED_MODULE_10__["HTTP_INTERCEPTORS"],
            useClass: _api_authorization_authorize_interceptor__WEBPACK_IMPORTED_MODULE_23__["AuthorizeInterceptor"],
            multi: true
          }],
          bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_3__["AppComponent"]]
        }]
      }], null, null);
    })();
    /***/

  },

  /***/
  "./src/app/feed-container/feed-container.component.ts":
  /*!************************************************************!*\
    !*** ./src/app/feed-container/feed-container.component.ts ***!
    \************************************************************/

  /*! exports provided: FeedContainerComponent */

  /***/
  function srcAppFeedContainerFeedContainerComponentTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "FeedContainerComponent", function () {
      return FeedContainerComponent;
    });
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
    /* harmony import */


    var _angular_material_tabs__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/material/tabs */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/tabs.js");
    /* harmony import */


    var _my_feed_my_feed_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! ../my-feed/my-feed.component */
    "./src/app/my-feed/my-feed.component.ts");
    /* harmony import */


    var _news_feed_news_feed_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
    /*! ../news-feed/news-feed.component */
    "./src/app/news-feed/news-feed.component.ts");
    /* harmony import */


    var _angular_material_icon__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(
    /*! @angular/material/icon */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/icon.js");

    function FeedContainerComponent_ng_template_2_Template(rf, ctx) {
      if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "mat-icon");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1, "chat_bubble_outline");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](2, " My Feed ");
      }
    }

    function FeedContainerComponent_ng_template_5_Template(rf, ctx) {
      if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "mat-icon");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1, "trending_up");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](2, " Trending ");
      }
    }

    function FeedContainerComponent_ng_template_8_Template(rf, ctx) {
      if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "mat-icon");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1, "rss_feed");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](2, " News ");
      }
    }

    var FeedContainerComponent = /*#__PURE__*/function () {
      function FeedContainerComponent() {
        _classCallCheck(this, FeedContainerComponent);
      }

      _createClass(FeedContainerComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {}
      }]);

      return FeedContainerComponent;
    }();

    FeedContainerComponent.ɵfac = function FeedContainerComponent_Factory(t) {
      return new (t || FeedContainerComponent)();
    };

    FeedContainerComponent.ɵcmp = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineComponent"]({
      type: FeedContainerComponent,
      selectors: [["app-feed-container"]],
      decls: 10,
      vars: 0,
      consts: [["mat-align-tabs", "center", "backgroundColor", "primary", "color", "accent"], ["mat-tab-label", ""], ["label", "Trending"], ["label", "News"]],
      template: function FeedContainerComponent_Template(rf, ctx) {
        if (rf & 1) {
          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "mat-tab-group", 0);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](1, "mat-tab");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](2, FeedContainerComponent_ng_template_2_Template, 3, 0, "ng-template", 1);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](3, "app-my-feed");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](4, "mat-tab", 2);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](5, FeedContainerComponent_ng_template_5_Template, 3, 0, "ng-template", 1);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](6, " Content 3");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](7, "mat-tab", 3);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](8, FeedContainerComponent_ng_template_8_Template, 3, 0, "ng-template", 1);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](9, "app-news-feed");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        }
      },
      directives: [_angular_material_tabs__WEBPACK_IMPORTED_MODULE_1__["MatTabGroup"], _angular_material_tabs__WEBPACK_IMPORTED_MODULE_1__["MatTab"], _angular_material_tabs__WEBPACK_IMPORTED_MODULE_1__["MatTabLabel"], _my_feed_my_feed_component__WEBPACK_IMPORTED_MODULE_2__["MyFeedComponent"], _news_feed_news_feed_component__WEBPACK_IMPORTED_MODULE_3__["NewsFeedComponent"], _angular_material_icon__WEBPACK_IMPORTED_MODULE_4__["MatIcon"]],
      styles: [".mat-tab-group[_ngcontent-%COMP%] {\r\n    margin-top: 10px;\r\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvZmVlZC1jb250YWluZXIvZmVlZC1jb250YWluZXIuY29tcG9uZW50LmNzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtJQUNJLGdCQUFnQjtBQUNwQiIsImZpbGUiOiJzcmMvYXBwL2ZlZWQtY29udGFpbmVyL2ZlZWQtY29udGFpbmVyLmNvbXBvbmVudC5jc3MiLCJzb3VyY2VzQ29udGVudCI6WyIubWF0LXRhYi1ncm91cCB7XHJcbiAgICBtYXJnaW4tdG9wOiAxMHB4O1xyXG59Il19 */"]
    });
    /*@__PURE__*/

    (function () {
      _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](FeedContainerComponent, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"],
        args: [{
          selector: 'app-feed-container',
          templateUrl: './feed-container.component.html',
          styleUrls: ['./feed-container.component.css']
        }]
      }], function () {
        return [];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/app/home/home.component.ts":
  /*!****************************************!*\
    !*** ./src/app/home/home.component.ts ***!
    \****************************************/

  /*! exports provided: HomeComponent */

  /***/
  function srcAppHomeHomeComponentTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "HomeComponent", function () {
      return HomeComponent;
    });
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
    /* harmony import */


    var _watchlist_watchlist_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! ../watchlist/watchlist.component */
    "./src/app/watchlist/watchlist.component.ts");
    /* harmony import */


    var _submit_post_form_submit_post_form_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! ../submit-post-form/submit-post-form.component */
    "./src/app/submit-post-form/submit-post-form.component.ts");
    /* harmony import */


    var _feed_container_feed_container_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
    /*! ../feed-container/feed-container.component */
    "./src/app/feed-container/feed-container.component.ts");

    var HomeComponent = function HomeComponent() {
      _classCallCheck(this, HomeComponent);
    };

    HomeComponent.ɵfac = function HomeComponent_Factory(t) {
      return new (t || HomeComponent)();
    };

    HomeComponent.ɵcmp = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineComponent"]({
      type: HomeComponent,
      selectors: [["app-home"]],
      decls: 9,
      vars: 0,
      consts: [[1, "flexbox-container"], [1, "flexbox-item", "side-navigation"], [1, "flexbox-item", "main-content"], [1, "flex-main-content"], [1, "flex-main-content-item1"], [1, "flex-main-content-item2"]],
      template: function HomeComponent_Template(rf, ctx) {
        if (rf & 1) {
          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "div", 0);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](1, "div", 1);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](2, "app-watchlist");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](3, "div", 2);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](4, "div", 3);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](5, "div", 4);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](6, "app-submit-post-form");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](7, "div", 5);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](8, "app-feed-container");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        }
      },
      directives: [_watchlist_watchlist_component__WEBPACK_IMPORTED_MODULE_1__["WatchlistComponent"], _submit_post_form_submit_post_form_component__WEBPACK_IMPORTED_MODULE_2__["SubmitPostFormComponent"], _feed_container_feed_container_component__WEBPACK_IMPORTED_MODULE_3__["FeedContainerComponent"]],
      styles: [".flexbox-container[_ngcontent-%COMP%] {\r\n    display: flex;    \r\n}\r\n\r\n.flexbox-item[_ngcontent-%COMP%] {\r\n    width: 200px;\r\n    margin: 10px;\r\n    min-height: 200px;\r\n    \r\n}\r\n\r\n.side-navigation[_ngcontent-%COMP%] {    \r\n    flex-shrink: 0;\r\n    width: 250px;\r\n}\r\n\r\n.main-content[_ngcontent-%COMP%] {\r\n    flex-grow: 1;\r\n}\r\n\r\n\r\n\r\n.flex-main-content[_ngcontent-%COMP%] {\r\n    display: flex;\r\n    flex-direction: column;\r\n}\r\n\r\n.flex-main-content-item1[_ngcontent-%COMP%] {\r\n    flex-shrink: 0;\r\n}\r\n\r\n.flex-main-content-item2[_ngcontent-%COMP%] {\r\n    flex-grow: 1;\r\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvaG9tZS9ob21lLmNvbXBvbmVudC5jc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7SUFDSSxhQUFhO0FBQ2pCOztBQUVBO0lBQ0ksWUFBWTtJQUNaLFlBQVk7SUFDWixpQkFBaUI7SUFDakI7Z0NBQzRCO0FBQ2hDOztBQUVBO0lBQ0ksY0FBYztJQUNkLFlBQVk7QUFDaEI7O0FBRUE7SUFDSSxZQUFZO0FBQ2hCOztBQUVDLGtDQUFrQzs7QUFFbkM7SUFDSSxhQUFhO0lBQ2Isc0JBQXNCO0FBQzFCOztBQUVBO0lBQ0ksY0FBYztBQUNsQjs7QUFFQTtJQUNJLFlBQVk7QUFDaEIiLCJmaWxlIjoic3JjL2FwcC9ob21lL2hvbWUuY29tcG9uZW50LmNzcyIsInNvdXJjZXNDb250ZW50IjpbIi5mbGV4Ym94LWNvbnRhaW5lciB7XHJcbiAgICBkaXNwbGF5OiBmbGV4OyAgICBcclxufVxyXG5cclxuLmZsZXhib3gtaXRlbSB7XHJcbiAgICB3aWR0aDogMjAwcHg7XHJcbiAgICBtYXJnaW46IDEwcHg7XHJcbiAgICBtaW4taGVpZ2h0OiAyMDBweDtcclxuICAgIC8qIGJvcmRlcjogM3B4IHNvbGlkICMzMzM7XHJcbiAgICBiYWNrZ3JvdW5kLWNvbG9yOiAjZGZkZmRmOyAqL1xyXG59XHJcblxyXG4uc2lkZS1uYXZpZ2F0aW9uIHsgICAgXHJcbiAgICBmbGV4LXNocmluazogMDtcclxuICAgIHdpZHRoOiAyNTBweDtcclxufVxyXG5cclxuLm1haW4tY29udGVudCB7XHJcbiAgICBmbGV4LWdyb3c6IDE7XHJcbn1cclxuXHJcbiAvKiBjb2x1bW4gZmxleCBkaXJlY3Rpb24gY29udGVudCAqL1xyXG5cclxuLmZsZXgtbWFpbi1jb250ZW50IHtcclxuICAgIGRpc3BsYXk6IGZsZXg7XHJcbiAgICBmbGV4LWRpcmVjdGlvbjogY29sdW1uO1xyXG59XHJcblxyXG4uZmxleC1tYWluLWNvbnRlbnQtaXRlbTEge1xyXG4gICAgZmxleC1zaHJpbms6IDA7XHJcbn1cclxuXHJcbi5mbGV4LW1haW4tY29udGVudC1pdGVtMiB7XHJcbiAgICBmbGV4LWdyb3c6IDE7XHJcbn0iXX0= */"]
    });
    /*@__PURE__*/

    (function () {
      _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](HomeComponent, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"],
        args: [{
          selector: 'app-home',
          templateUrl: './home.component.html',
          styleUrls: ['./home.component.css']
        }]
      }], null, null);
    })();
    /***/

  },

  /***/
  "./src/app/my-feed/my-feed.component.ts":
  /*!**********************************************!*\
    !*** ./src/app/my-feed/my-feed.component.ts ***!
    \**********************************************/

  /*! exports provided: MyFeedComponent */

  /***/
  function srcAppMyFeedMyFeedComponentTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "MyFeedComponent", function () {
      return MyFeedComponent;
    });
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
    /* harmony import */


    var _my_feed_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! ./my-feed.service */
    "./src/app/my-feed/my-feed.service.ts");
    /* harmony import */


    var _angular_material_button_toggle__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! @angular/material/button-toggle */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/button-toggle.js");
    /* harmony import */


    var _angular_common__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
    /*! @angular/common */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/common.js");
    /* harmony import */


    var _angular_material_card__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(
    /*! @angular/material/card */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/card.js");
    /* harmony import */


    var _angular_router__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(
    /*! @angular/router */
    "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");
    /* harmony import */


    var _angular_material_button__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(
    /*! @angular/material/button */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/button.js");
    /* harmony import */


    var _angular_material_icon__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(
    /*! @angular/material/icon */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/icon.js");
    /* harmony import */


    var _angular_material_divider__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(
    /*! @angular/material/divider */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/divider.js");
    /* harmony import */


    var _angular_material_badge__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(
    /*! @angular/material/badge */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/badge.js");
    /* harmony import */


    var _pipes_linkify_pipe__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(
    /*! ../pipes/linkify-pipe */
    "./src/app/pipes/linkify-pipe.ts");

    function MyFeedComponent_div_10_div_10_Template(rf, ctx) {
      if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "div", 14);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1, "Bullish");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
      }
    }

    function MyFeedComponent_div_10_div_11_Template(rf, ctx) {
      if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "div", 15);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1, "Bearish");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
      }
    }

    function MyFeedComponent_div_10_span_23_Template(rf, ctx) {
      if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](0, "span", 16);
      }

      if (rf & 2) {
        var post_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵnextContext"]().$implicit;

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpropertyInterpolate"]("matBadge", post_r1.responseCount);
      }
    }

    function MyFeedComponent_div_10_span_27_Template(rf, ctx) {
      if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](0, "span", 16);
      }

      if (rf & 2) {
        var post_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵnextContext"]().$implicit;

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpropertyInterpolate"]("matBadge", post_r1.likeCount);
      }
    }

    var _c0 = function _c0(a1) {
      return ["/post", a1];
    };

    function MyFeedComponent_div_10_Template(rf, ctx) {
      if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "div");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](1, "mat-card", 4);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](2, "mat-card-header");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](3, "div", 5);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](4, "mat-card-subtitle");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](5, "div");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](6);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](7, "br");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](8);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](9, "div", 6);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](10, MyFeedComponent_div_10_div_10_Template, 2, 0, "div", 7);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](11, MyFeedComponent_div_10_div_11_Template, 2, 0, "div", 8);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](12, "mat-card-content");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](13, "p", 9);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpipe"](14, "linkify");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](15, "mat-card-actions");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](16, "button", 10);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](17, "mat-icon", 11);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](18, "reply");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](19, "button", 10);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](20, "mat-icon", 11);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](21, "format_quote");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](22, "button", 10);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](23, MyFeedComponent_div_10_span_23_Template, 1, 1, "span", 12);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](24, "mat-icon", 11);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](25, "mode_comment");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](26, "button", 10);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](27, MyFeedComponent_div_10_span_27_Template, 1, 1, "span", 12);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](28, "mat-icon", 13);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](29, "mat-divider");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
      }

      if (rf & 2) {
        var post_r1 = ctx.$implicit;

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("routerLink", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpureFunction1"](10, _c0, post_r1.postId));

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](5);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtextInterpolate1"](" ", post_r1.userName, " ");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](2);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtextInterpolate1"](" Posted ", post_r1.postDate, " ");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](2);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", post_r1.bullBearLevel == "VeryBullish");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", post_r1.bullBearLevel == "VeryBearish");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](2);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("innerHTML", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpipeBind1"](14, 8, post_r1.postText), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵsanitizeHtml"]);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](10);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", post_r1.responseCount > 0);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](4);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", post_r1.likeCount > 0);
      }
    }

    var MyFeedComponent = /*#__PURE__*/function () {
      function MyFeedComponent(myFeedService) {
        _classCallCheck(this, MyFeedComponent);

        this.myFeedService = myFeedService;
      }

      _createClass(MyFeedComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {
          var _this6 = this;

          this.myFeedService.getMyFeed().subscribe(function (result) {
            _this6.myFeed = result;
            console.log(_this6.myFeed);
          }, function (error) {
            return console.error(error);
          });
        }
      }, {
        key: "goToPost",
        value: function goToPost() {
          console.log('hello');
        }
      }]);

      return MyFeedComponent;
    }();

    MyFeedComponent.ɵfac = function MyFeedComponent_Factory(t) {
      return new (t || MyFeedComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdirectiveInject"](_my_feed_service__WEBPACK_IMPORTED_MODULE_1__["MyFeedService"]));
    };

    MyFeedComponent.ɵcmp = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineComponent"]({
      type: MyFeedComponent,
      selectors: [["app-my-feed"]],
      decls: 11,
      vars: 1,
      consts: [[1, "feed-filter"], ["appearance", "legacy"], ["checked", ""], [4, "ngFor", "ngForOf"], [3, "routerLink"], ["mat-card-avatar", "", 1, "example-header-image"], [1, "bearbullindicator"], ["class", "bearbullindicator1 bullish", 4, "ngIf"], ["class", "bearbullindicator1 bearish", 4, "ngIf"], [3, "innerHTML"], ["mat-icon-button", ""], [1, "icon-display"], ["matBadgePosition", "before", "matBadgeColor", "accent", "matBadgeSize", "small", 3, "matBadge", 4, "ngIf"], ["svgIcon", "like", 1, "icon-display"], [1, "bearbullindicator1", "bullish"], [1, "bearbullindicator1", "bearish"], ["matBadgePosition", "before", "matBadgeColor", "accent", "matBadgeSize", "small", 3, "matBadge"]],
      template: function MyFeedComponent_Template(rf, ctx) {
        if (rf & 1) {
          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "div", 0);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](1, "mat-button-toggle-group", 1);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](2, "mat-button-toggle", 2);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](3, "All");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](4, "mat-button-toggle");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](5, "Mentions");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](6, "mat-button-toggle");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](7, "Watch List");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](8, "mat-button-toggle");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](9, "Subscription");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](10, MyFeedComponent_div_10_Template, 30, 12, "div", 3);
        }

        if (rf & 2) {
          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](10);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngForOf", ctx.myFeed);
        }
      },
      directives: [_angular_material_button_toggle__WEBPACK_IMPORTED_MODULE_2__["MatButtonToggleGroup"], _angular_material_button_toggle__WEBPACK_IMPORTED_MODULE_2__["MatButtonToggle"], _angular_common__WEBPACK_IMPORTED_MODULE_3__["NgForOf"], _angular_material_card__WEBPACK_IMPORTED_MODULE_4__["MatCard"], _angular_router__WEBPACK_IMPORTED_MODULE_5__["RouterLink"], _angular_material_card__WEBPACK_IMPORTED_MODULE_4__["MatCardHeader"], _angular_material_card__WEBPACK_IMPORTED_MODULE_4__["MatCardAvatar"], _angular_material_card__WEBPACK_IMPORTED_MODULE_4__["MatCardSubtitle"], _angular_common__WEBPACK_IMPORTED_MODULE_3__["NgIf"], _angular_material_card__WEBPACK_IMPORTED_MODULE_4__["MatCardContent"], _angular_material_card__WEBPACK_IMPORTED_MODULE_4__["MatCardActions"], _angular_material_button__WEBPACK_IMPORTED_MODULE_6__["MatButton"], _angular_material_icon__WEBPACK_IMPORTED_MODULE_7__["MatIcon"], _angular_material_divider__WEBPACK_IMPORTED_MODULE_8__["MatDivider"], _angular_material_badge__WEBPACK_IMPORTED_MODULE_9__["MatBadge"]],
      pipes: [_pipes_linkify_pipe__WEBPACK_IMPORTED_MODULE_10__["LinkifyPipe"]],
      styles: [".mat-card[_ngcontent-%COMP%] {\r\n    cursor: pointer;\r\n}\r\n\r\n.mat-card[_ngcontent-%COMP%]:hover {\r\n    background-color: #efefef;\r\n}\r\n\r\n.mat-card-header[_ngcontent-%COMP%] {\r\n    display: flex;\r\n}\r\n\r\n.mat-card-subtitle[_ngcontent-%COMP%] {\r\n    flex-shrink: 0;\r\n}\r\n\r\n.mat-card-actions[_ngcontent-%COMP%] {\r\n    height: -webkit-fit-content;\r\n    height: -moz-fit-content;\r\n    height: fit-content;\r\n}\r\n\r\n.example-header-image[_ngcontent-%COMP%] {\r\n    background-image: url('https://material.angular.io/assets/img/examples/shiba1.jpg');\r\n    background-size: cover;\r\n}\r\n\r\n.mat-button-toggle-group[_ngcontent-%COMP%] {\r\n    margin: 10px;\r\n}\r\n\r\n.feed-filter[_ngcontent-%COMP%] {\r\n    width: 100%;\r\n    text-align: center;\r\n}\r\n\r\nbutton[_ngcontent-%COMP%] {\r\n    color: grey;\r\n}\r\n\r\n.bearbullindicator[_ngcontent-%COMP%] {    \r\n    color: white;\r\n    width: 50px;    \r\n    text-align: center;\r\n    height: 25px;\r\n    font-size: 9pt;\r\n    float: right;\r\n}\r\n\r\n.bullish[_ngcontent-%COMP%] {\r\n    background-color: green;\r\n}\r\n\r\n.bearish[_ngcontent-%COMP%] {\r\n    background-color: red;\r\n}\r\n\r\n.icon-display[_ngcontent-%COMP%] {\r\n    transform: scale(0.7);\r\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbXktZmVlZC9teS1mZWVkLmNvbXBvbmVudC5jc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7SUFDSSxlQUFlO0FBQ25COztBQUVBO0lBQ0kseUJBQXlCO0FBQzdCOztBQUVBO0lBQ0ksYUFBYTtBQUNqQjs7QUFFQTtJQUNJLGNBQWM7QUFDbEI7O0FBRUE7SUFDSSwyQkFBbUI7SUFBbkIsd0JBQW1CO0lBQW5CLG1CQUFtQjtBQUN2Qjs7QUFFQTtJQUNJLG1GQUFtRjtJQUNuRixzQkFBc0I7QUFDMUI7O0FBRUE7SUFDSSxZQUFZO0FBQ2hCOztBQUVBO0lBQ0ksV0FBVztJQUNYLGtCQUFrQjtBQUN0Qjs7QUFFQTtJQUNJLFdBQVc7QUFDZjs7QUFFQTtJQUNJLFlBQVk7SUFDWixXQUFXO0lBQ1gsa0JBQWtCO0lBQ2xCLFlBQVk7SUFDWixjQUFjO0lBQ2QsWUFBWTtBQUNoQjs7QUFFQTtJQUNJLHVCQUF1QjtBQUMzQjs7QUFFQTtJQUNJLHFCQUFxQjtBQUN6Qjs7QUFFQTtJQUNJLHFCQUFxQjtBQUN6QiIsImZpbGUiOiJzcmMvYXBwL215LWZlZWQvbXktZmVlZC5jb21wb25lbnQuY3NzIiwic291cmNlc0NvbnRlbnQiOlsiLm1hdC1jYXJkIHtcclxuICAgIGN1cnNvcjogcG9pbnRlcjtcclxufVxyXG5cclxuLm1hdC1jYXJkOmhvdmVyIHtcclxuICAgIGJhY2tncm91bmQtY29sb3I6ICNlZmVmZWY7XHJcbn1cclxuXHJcbi5tYXQtY2FyZC1oZWFkZXIge1xyXG4gICAgZGlzcGxheTogZmxleDtcclxufVxyXG5cclxuLm1hdC1jYXJkLXN1YnRpdGxlIHtcclxuICAgIGZsZXgtc2hyaW5rOiAwO1xyXG59XHJcblxyXG4ubWF0LWNhcmQtYWN0aW9ucyB7XHJcbiAgICBoZWlnaHQ6IGZpdC1jb250ZW50O1xyXG59XHJcblxyXG4uZXhhbXBsZS1oZWFkZXItaW1hZ2Uge1xyXG4gICAgYmFja2dyb3VuZC1pbWFnZTogdXJsKCdodHRwczovL21hdGVyaWFsLmFuZ3VsYXIuaW8vYXNzZXRzL2ltZy9leGFtcGxlcy9zaGliYTEuanBnJyk7XHJcbiAgICBiYWNrZ3JvdW5kLXNpemU6IGNvdmVyO1xyXG59XHJcblxyXG4ubWF0LWJ1dHRvbi10b2dnbGUtZ3JvdXAge1xyXG4gICAgbWFyZ2luOiAxMHB4O1xyXG59XHJcblxyXG4uZmVlZC1maWx0ZXIge1xyXG4gICAgd2lkdGg6IDEwMCU7XHJcbiAgICB0ZXh0LWFsaWduOiBjZW50ZXI7XHJcbn1cclxuXHJcbmJ1dHRvbiB7XHJcbiAgICBjb2xvcjogZ3JleTtcclxufVxyXG5cclxuLmJlYXJidWxsaW5kaWNhdG9yIHsgICAgXHJcbiAgICBjb2xvcjogd2hpdGU7XHJcbiAgICB3aWR0aDogNTBweDsgICAgXHJcbiAgICB0ZXh0LWFsaWduOiBjZW50ZXI7XHJcbiAgICBoZWlnaHQ6IDI1cHg7XHJcbiAgICBmb250LXNpemU6IDlwdDtcclxuICAgIGZsb2F0OiByaWdodDtcclxufVxyXG5cclxuLmJ1bGxpc2gge1xyXG4gICAgYmFja2dyb3VuZC1jb2xvcjogZ3JlZW47XHJcbn1cclxuXHJcbi5iZWFyaXNoIHtcclxuICAgIGJhY2tncm91bmQtY29sb3I6IHJlZDtcclxufVxyXG5cclxuLmljb24tZGlzcGxheSB7XHJcbiAgICB0cmFuc2Zvcm06IHNjYWxlKDAuNyk7XHJcbn0iXX0= */"]
    });
    /*@__PURE__*/

    (function () {
      _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](MyFeedComponent, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"],
        args: [{
          selector: 'app-my-feed',
          templateUrl: './my-feed.component.html',
          styleUrls: ['./my-feed.component.css']
        }]
      }], function () {
        return [{
          type: _my_feed_service__WEBPACK_IMPORTED_MODULE_1__["MyFeedService"]
        }];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/app/my-feed/my-feed.service.ts":
  /*!********************************************!*\
    !*** ./src/app/my-feed/my-feed.service.ts ***!
    \********************************************/

  /*! exports provided: MyFeedService */

  /***/
  function srcAppMyFeedMyFeedServiceTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "MyFeedService", function () {
      return MyFeedService;
    });
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
    /* harmony import */


    var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/common/http */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/http.js");

    var MyFeedService = /*#__PURE__*/function () {
      function MyFeedService(http) {
        _classCallCheck(this, MyFeedService);

        this.http = http;
      }

      _createClass(MyFeedService, [{
        key: "getMyFeed",
        value: function getMyFeed() {
          var url = './assets/myfeed.json';
          return this.http.get(url);
        }
      }]);

      return MyFeedService;
    }();

    MyFeedService.ɵfac = function MyFeedService_Factory(t) {
      return new (t || MyFeedService)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"](_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]));
    };

    MyFeedService.ɵprov = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineInjectable"]({
      token: MyFeedService,
      factory: MyFeedService.ɵfac,
      providedIn: 'root'
    });
    /*@__PURE__*/

    (function () {
      _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](MyFeedService, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"],
        args: [{
          providedIn: 'root'
        }]
      }], function () {
        return [{
          type: _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]
        }];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/app/nav-menu/nav-menu.component.ts":
  /*!************************************************!*\
    !*** ./src/app/nav-menu/nav-menu.component.ts ***!
    \************************************************/

  /*! exports provided: NavMenuComponent */

  /***/
  function srcAppNavMenuNavMenuComponentTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "NavMenuComponent", function () {
      return NavMenuComponent;
    });
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
    /* harmony import */


    var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/router */
    "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");
    /* harmony import */


    var _angular_common__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! @angular/common */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/common.js");
    /* harmony import */


    var _api_authorization_login_menu_login_menu_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
    /*! ../api-authorization/login-menu/login-menu.component */
    "./src/app/api-authorization/login-menu/login-menu.component.ts");
    /* harmony import */


    var _angular_material_form_field__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(
    /*! @angular/material/form-field */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/form-field.js");
    /* harmony import */


    var _angular_material_input__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(
    /*! @angular/material/input */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/input.js");
    /* harmony import */


    var _angular_material_icon__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(
    /*! @angular/material/icon */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/icon.js");

    var _c0 = function _c0() {
      return ["/"];
    };

    var _c1 = function _c1(a0) {
      return {
        show: a0
      };
    };

    var _c2 = function _c2() {
      return ["link-active"];
    };

    var _c3 = function _c3() {
      return {
        exact: true
      };
    };

    var NavMenuComponent = /*#__PURE__*/function () {
      function NavMenuComponent() {
        _classCallCheck(this, NavMenuComponent);

        this.isExpanded = false;
      }

      _createClass(NavMenuComponent, [{
        key: "collapse",
        value: function collapse() {
          this.isExpanded = false;
        }
      }, {
        key: "toggle",
        value: function toggle() {
          this.isExpanded = !this.isExpanded;
        }
      }]);

      return NavMenuComponent;
    }();

    NavMenuComponent.ɵfac = function NavMenuComponent_Factory(t) {
      return new (t || NavMenuComponent)();
    };

    NavMenuComponent.ɵcmp = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineComponent"]({
      type: NavMenuComponent,
      selectors: [["app-nav-menu"]],
      decls: 18,
      vars: 12,
      consts: [[1, "navbar", "navbar-expand-sm", "navbar-toggleable-sm", "navbar-light", "bg-white", "border-bottom", "box-shadow", "mb-3"], [1, "container"], [1, "navbar-brand", 3, "routerLink"], ["alt", "Titos & Titas of Finance Logo", "src", "./assets/TandT-150x83-logo.png"], ["type", "button", "data-toggle", "collapse", "data-target", ".navbar-collapse", "aria-label", "Toggle navigation", 1, "navbar-toggler", 3, "click"], [1, "navbar-toggler-icon"], [1, "navbar-collapse", "collapse", "d-sm-inline-flex", "flex-sm-row-reverse", 3, "ngClass"], [1, "navbar-nav", "flex-grow"], [1, "nav-item", 3, "routerLinkActive", "routerLinkActiveOptions"], [1, "nav-link", "text-dark", 3, "routerLink"], [1, "searchFormField"], ["matInput", "", "id", "searchBox", "placeholder", "Search"], ["matSuffix", ""]],
      template: function NavMenuComponent_Template(rf, ctx) {
        if (rf & 1) {
          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "header");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](1, "nav", 0);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](2, "div", 1);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](3, "a", 2);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](4, "img", 3);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](5, "button", 4);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵlistener"]("click", function NavMenuComponent_Template_button_click_5_listener() {
            return ctx.toggle();
          });

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](6, "span", 5);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](7, "div", 6);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](8, "app-login-menu");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](9, "ul", 7);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](10, "li", 8);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](11, "a", 9);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](12, "Home");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](13, "div", 10);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](14, "mat-form-field");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](15, "input", 11);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](16, "mat-icon", 12);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](17, "search");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        }

        if (rf & 2) {
          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](3);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("routerLink", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpureFunction0"](6, _c0));

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](2);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵattribute"]("aria-expanded", ctx.isExpanded);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](2);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngClass", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpureFunction1"](7, _c1, ctx.isExpanded));

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](3);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("routerLinkActive", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpureFunction0"](9, _c2))("routerLinkActiveOptions", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpureFunction0"](10, _c3));

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("routerLink", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpureFunction0"](11, _c0));
        }
      },
      directives: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterLinkWithHref"], _angular_common__WEBPACK_IMPORTED_MODULE_2__["NgClass"], _api_authorization_login_menu_login_menu_component__WEBPACK_IMPORTED_MODULE_3__["LoginMenuComponent"], _angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterLinkActive"], _angular_material_form_field__WEBPACK_IMPORTED_MODULE_4__["MatFormField"], _angular_material_input__WEBPACK_IMPORTED_MODULE_5__["MatInput"], _angular_material_icon__WEBPACK_IMPORTED_MODULE_6__["MatIcon"], _angular_material_form_field__WEBPACK_IMPORTED_MODULE_4__["MatSuffix"]],
      styles: ["a.navbar-brand[_ngcontent-%COMP%] {\r\n    white-space: normal;\r\n    text-align: center;\r\n    word-break: break-all;\r\n  }\r\n  \r\n  html[_ngcontent-%COMP%] {\r\n    font-size: 14px;\r\n  }\r\n  \r\n  @media (min-width: 768px) {\r\n    html[_ngcontent-%COMP%] {\r\n      font-size: 16px;\r\n    }\r\n  }\r\n  \r\n  .box-shadow[_ngcontent-%COMP%] {\r\n    box-shadow: 0 .25rem .75rem rgba(0, 0, 0, .05);\r\n  }\r\n  \r\n  .searchFormField[_ngcontent-%COMP%] {\r\n    width: 100%;\r\n    text-align: center;\r\n  }\r\n  \r\n  .mat-form-field[_ngcontent-%COMP%] {\r\n    width: 75%;\r\n  }\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbmF2LW1lbnUvbmF2LW1lbnUuY29tcG9uZW50LmNzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtJQUNJLG1CQUFtQjtJQUNuQixrQkFBa0I7SUFDbEIscUJBQXFCO0VBQ3ZCOztFQUVBO0lBQ0UsZUFBZTtFQUNqQjs7RUFDQTtJQUNFO01BQ0UsZUFBZTtJQUNqQjtFQUNGOztFQUVBO0lBQ0UsOENBQThDO0VBQ2hEOztFQUVBO0lBQ0UsV0FBVztJQUNYLGtCQUFrQjtFQUNwQjs7RUFFQTtJQUNFLFVBQVU7RUFDWiIsImZpbGUiOiJzcmMvYXBwL25hdi1tZW51L25hdi1tZW51LmNvbXBvbmVudC5jc3MiLCJzb3VyY2VzQ29udGVudCI6WyJhLm5hdmJhci1icmFuZCB7XHJcbiAgICB3aGl0ZS1zcGFjZTogbm9ybWFsO1xyXG4gICAgdGV4dC1hbGlnbjogY2VudGVyO1xyXG4gICAgd29yZC1icmVhazogYnJlYWstYWxsO1xyXG4gIH1cclxuICBcclxuICBodG1sIHtcclxuICAgIGZvbnQtc2l6ZTogMTRweDtcclxuICB9XHJcbiAgQG1lZGlhIChtaW4td2lkdGg6IDc2OHB4KSB7XHJcbiAgICBodG1sIHtcclxuICAgICAgZm9udC1zaXplOiAxNnB4O1xyXG4gICAgfVxyXG4gIH1cclxuICBcclxuICAuYm94LXNoYWRvdyB7XHJcbiAgICBib3gtc2hhZG93OiAwIC4yNXJlbSAuNzVyZW0gcmdiYSgwLCAwLCAwLCAuMDUpO1xyXG4gIH1cclxuXHJcbiAgLnNlYXJjaEZvcm1GaWVsZCB7XHJcbiAgICB3aWR0aDogMTAwJTtcclxuICAgIHRleHQtYWxpZ246IGNlbnRlcjtcclxuICB9XHJcbiAgXHJcbiAgLm1hdC1mb3JtLWZpZWxkIHtcclxuICAgIHdpZHRoOiA3NSU7XHJcbiAgfSJdfQ== */"]
    });
    /*@__PURE__*/

    (function () {
      _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](NavMenuComponent, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"],
        args: [{
          selector: 'app-nav-menu',
          templateUrl: './nav-menu.component.html',
          styleUrls: ['./nav-menu.component.css']
        }]
      }], null, null);
    })();
    /***/

  },

  /***/
  "./src/app/news-feed/news-feed.component.ts":
  /*!**************************************************!*\
    !*** ./src/app/news-feed/news-feed.component.ts ***!
    \**************************************************/

  /*! exports provided: NewsFeedComponent */

  /***/
  function srcAppNewsFeedNewsFeedComponentTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "NewsFeedComponent", function () {
      return NewsFeedComponent;
    });
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
    /* harmony import */


    var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/common/http */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/http.js");
    /* harmony import */


    var _angular_common__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! @angular/common */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/common.js");
    /* harmony import */


    var _angular_material_card__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
    /*! @angular/material/card */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/card.js");
    /* harmony import */


    var _angular_material_button__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(
    /*! @angular/material/button */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/button.js");
    /* harmony import */


    var _angular_material_icon__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(
    /*! @angular/material/icon */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/icon.js");
    /* harmony import */


    var _angular_material_divider__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(
    /*! @angular/material/divider */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/divider.js");
    /* harmony import */


    var _pipes_stirp_html_pipe__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(
    /*! ../pipes/stirp-html-pipe */
    "./src/app/pipes/stirp-html-pipe.ts");

    function NewsFeedComponent_div_0_Template(rf, ctx) {
      if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "div");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](1, "mat-card");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](2, "mat-card-header");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](3, "div", 1);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](4, "mat-card-subtitle");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](5, "div");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](6, "a", 2);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](7, "EIN News");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](8, "br");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](9);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](10, "mat-card-content");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](11, "a", 3);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](12, "p");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](13);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](14);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpipe"](15, "striphtml");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](16, "mat-card-actions");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](17, "button", 4);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](18, "mat-icon", 5);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](19, "format_quote");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](20, "mat-divider");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
      }

      if (rf & 2) {
        var rss_r1 = ctx.$implicit;

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](9);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtextInterpolate1"](" Posted ", rss_r1.pubDate, " ");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](2);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpropertyInterpolate"]("href", rss_r1.link, _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵsanitizeUrl"]);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](2);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtextInterpolate"](rss_r1.title);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtextInterpolate1"](" ", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpipeBind1"](15, 4, rss_r1.description), " ");
      }
    } // import * as xml2js from "xml2js";
    // import { NewsRss } from './news-rss';


    var NewsFeedComponent = /*#__PURE__*/function () {
      function NewsFeedComponent(http) {
        _classCallCheck(this, NewsFeedComponent);

        this.http = http;
      }

      _createClass(NewsFeedComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {
          this.getRssFeedData();
        }
      }, {
        key: "getRssFeedData",
        value: function getRssFeedData() {
          var _this7 = this;

          this.http.get("./assets/news-feed.json").subscribe(function (data) {
            _this7.rssData = data; // if (this.rssData) {
            //   for(let i = 0; i < this.rssData.rss.channel.item.length; i++) {
            //     this.rssData.rss.channel.item[i].description = this.rssData.rss.channel.item[i].description.replace(/(<([^>]+)>|&#\d+;)/ig, "");
            //   }
            // }

            console.log(_this7.rssData.rss.channel);
          });
        }
      }]);

      return NewsFeedComponent;
    }();

    NewsFeedComponent.ɵfac = function NewsFeedComponent_Factory(t) {
      return new (t || NewsFeedComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdirectiveInject"](_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]));
    };

    NewsFeedComponent.ɵcmp = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineComponent"]({
      type: NewsFeedComponent,
      selectors: [["app-news-feed"]],
      decls: 1,
      vars: 1,
      consts: [[4, "ngFor", "ngForOf"], ["mat-card-avatar", "", 1, "example-header-image"], ["href", "https://investing.einnews.com/news/philippine-stock-exchange"], [3, "href"], ["mat-icon-button", ""], [1, "icon-display"]],
      template: function NewsFeedComponent_Template(rf, ctx) {
        if (rf & 1) {
          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](0, NewsFeedComponent_div_0_Template, 21, 6, "div", 0);
        }

        if (rf & 2) {
          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngForOf", ctx.rssData == null ? null : ctx.rssData.rss.channel.item);
        }
      },
      directives: [_angular_common__WEBPACK_IMPORTED_MODULE_2__["NgForOf"], _angular_material_card__WEBPACK_IMPORTED_MODULE_3__["MatCard"], _angular_material_card__WEBPACK_IMPORTED_MODULE_3__["MatCardHeader"], _angular_material_card__WEBPACK_IMPORTED_MODULE_3__["MatCardAvatar"], _angular_material_card__WEBPACK_IMPORTED_MODULE_3__["MatCardSubtitle"], _angular_material_card__WEBPACK_IMPORTED_MODULE_3__["MatCardContent"], _angular_material_card__WEBPACK_IMPORTED_MODULE_3__["MatCardActions"], _angular_material_button__WEBPACK_IMPORTED_MODULE_4__["MatButton"], _angular_material_icon__WEBPACK_IMPORTED_MODULE_5__["MatIcon"], _angular_material_divider__WEBPACK_IMPORTED_MODULE_6__["MatDivider"]],
      pipes: [_pipes_stirp_html_pipe__WEBPACK_IMPORTED_MODULE_7__["StripHtmlPipe"]],
      styles: [".mat-card-content[_ngcontent-%COMP%] {\r\n    word-wrap: normal;\r\n}\r\n\r\n.example-header-image[_ngcontent-%COMP%] {\r\n    background-image: url('https://material.angular.io/assets/img/examples/shiba1.jpg');\r\n    background-size: cover;\r\n}\r\n\r\n.icon-display[_ngcontent-%COMP%] {\r\n    transform: scale(0.7);\r\n}\r\n\r\nbutton[_ngcontent-%COMP%] {\r\n    color: grey;\r\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbmV3cy1mZWVkL25ld3MtZmVlZC5jb21wb25lbnQuY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0lBQ0ksaUJBQWlCO0FBQ3JCOztBQUVBO0lBQ0ksbUZBQW1GO0lBQ25GLHNCQUFzQjtBQUMxQjs7QUFHQTtJQUNJLHFCQUFxQjtBQUN6Qjs7QUFFQTtJQUNJLFdBQVc7QUFDZiIsImZpbGUiOiJzcmMvYXBwL25ld3MtZmVlZC9uZXdzLWZlZWQuY29tcG9uZW50LmNzcyIsInNvdXJjZXNDb250ZW50IjpbIi5tYXQtY2FyZC1jb250ZW50IHtcclxuICAgIHdvcmQtd3JhcDogbm9ybWFsO1xyXG59XHJcblxyXG4uZXhhbXBsZS1oZWFkZXItaW1hZ2Uge1xyXG4gICAgYmFja2dyb3VuZC1pbWFnZTogdXJsKCdodHRwczovL21hdGVyaWFsLmFuZ3VsYXIuaW8vYXNzZXRzL2ltZy9leGFtcGxlcy9zaGliYTEuanBnJyk7XHJcbiAgICBiYWNrZ3JvdW5kLXNpemU6IGNvdmVyO1xyXG59XHJcblxyXG5cclxuLmljb24tZGlzcGxheSB7XHJcbiAgICB0cmFuc2Zvcm06IHNjYWxlKDAuNyk7XHJcbn1cclxuXHJcbmJ1dHRvbiB7XHJcbiAgICBjb2xvcjogZ3JleTtcclxufSJdfQ== */"]
    });
    /*@__PURE__*/

    (function () {
      _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](NewsFeedComponent, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"],
        args: [{
          selector: 'app-news-feed',
          templateUrl: './news-feed.component.html',
          styleUrls: ['./news-feed.component.css']
        }]
      }], function () {
        return [{
          type: _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]
        }];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/app/ngmaterial/ngmaterial.module.ts":
  /*!*************************************************!*\
    !*** ./src/app/ngmaterial/ngmaterial.module.ts ***!
    \*************************************************/

  /*! exports provided: NgMaterialModule */

  /***/
  function srcAppNgmaterialNgmaterialModuleTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "NgMaterialModule", function () {
      return NgMaterialModule;
    });
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
    /* harmony import */


    var _angular_material_input__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/material/input */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/input.js");
    /* harmony import */


    var _angular_material_table__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! @angular/material/table */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/table.js");
    /* harmony import */


    var _angular_material_icon__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
    /*! @angular/material/icon */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/icon.js");
    /* harmony import */


    var _angular_material_button__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(
    /*! @angular/material/button */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/button.js");
    /* harmony import */


    var _angular_material_button_toggle__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(
    /*! @angular/material/button-toggle */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/button-toggle.js");
    /* harmony import */


    var _angular_material_tabs__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(
    /*! @angular/material/tabs */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/tabs.js");
    /* harmony import */


    var _angular_material_card__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(
    /*! @angular/material/card */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/card.js");
    /* harmony import */


    var _angular_material_divider__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(
    /*! @angular/material/divider */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/divider.js");
    /* harmony import */


    var _angular_material_badge__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(
    /*! @angular/material/badge */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/badge.js");

    var NgMaterialModule = function NgMaterialModule() {
      _classCallCheck(this, NgMaterialModule);
    };

    NgMaterialModule.ɵmod = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineNgModule"]({
      type: NgMaterialModule
    });
    NgMaterialModule.ɵinj = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineInjector"]({
      factory: function NgMaterialModule_Factory(t) {
        return new (t || NgMaterialModule)();
      },
      imports: [[_angular_material_input__WEBPACK_IMPORTED_MODULE_1__["MatInputModule"], _angular_material_table__WEBPACK_IMPORTED_MODULE_2__["MatTableModule"], _angular_material_icon__WEBPACK_IMPORTED_MODULE_3__["MatIconModule"], _angular_material_button__WEBPACK_IMPORTED_MODULE_4__["MatButtonModule"], _angular_material_button_toggle__WEBPACK_IMPORTED_MODULE_5__["MatButtonToggleModule"], _angular_material_tabs__WEBPACK_IMPORTED_MODULE_6__["MatTabsModule"], _angular_material_card__WEBPACK_IMPORTED_MODULE_7__["MatCardModule"], _angular_material_divider__WEBPACK_IMPORTED_MODULE_8__["MatDividerModule"], _angular_material_badge__WEBPACK_IMPORTED_MODULE_9__["MatBadgeModule"]], // CommonModule,
      _angular_material_input__WEBPACK_IMPORTED_MODULE_1__["MatInputModule"], _angular_material_table__WEBPACK_IMPORTED_MODULE_2__["MatTableModule"], _angular_material_icon__WEBPACK_IMPORTED_MODULE_3__["MatIconModule"], _angular_material_button__WEBPACK_IMPORTED_MODULE_4__["MatButtonModule"], _angular_material_button_toggle__WEBPACK_IMPORTED_MODULE_5__["MatButtonToggleModule"], _angular_material_tabs__WEBPACK_IMPORTED_MODULE_6__["MatTabsModule"], _angular_material_card__WEBPACK_IMPORTED_MODULE_7__["MatCardModule"], _angular_material_divider__WEBPACK_IMPORTED_MODULE_8__["MatDividerModule"], _angular_material_badge__WEBPACK_IMPORTED_MODULE_9__["MatBadgeModule"]]
    });

    (function () {
      (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵsetNgModuleScope"](NgMaterialModule, {
        imports: [_angular_material_input__WEBPACK_IMPORTED_MODULE_1__["MatInputModule"], _angular_material_table__WEBPACK_IMPORTED_MODULE_2__["MatTableModule"], _angular_material_icon__WEBPACK_IMPORTED_MODULE_3__["MatIconModule"], _angular_material_button__WEBPACK_IMPORTED_MODULE_4__["MatButtonModule"], _angular_material_button_toggle__WEBPACK_IMPORTED_MODULE_5__["MatButtonToggleModule"], _angular_material_tabs__WEBPACK_IMPORTED_MODULE_6__["MatTabsModule"], _angular_material_card__WEBPACK_IMPORTED_MODULE_7__["MatCardModule"], _angular_material_divider__WEBPACK_IMPORTED_MODULE_8__["MatDividerModule"], _angular_material_badge__WEBPACK_IMPORTED_MODULE_9__["MatBadgeModule"]],
        exports: [// CommonModule,
        _angular_material_input__WEBPACK_IMPORTED_MODULE_1__["MatInputModule"], _angular_material_table__WEBPACK_IMPORTED_MODULE_2__["MatTableModule"], _angular_material_icon__WEBPACK_IMPORTED_MODULE_3__["MatIconModule"], _angular_material_button__WEBPACK_IMPORTED_MODULE_4__["MatButtonModule"], _angular_material_button_toggle__WEBPACK_IMPORTED_MODULE_5__["MatButtonToggleModule"], _angular_material_tabs__WEBPACK_IMPORTED_MODULE_6__["MatTabsModule"], _angular_material_card__WEBPACK_IMPORTED_MODULE_7__["MatCardModule"], _angular_material_divider__WEBPACK_IMPORTED_MODULE_8__["MatDividerModule"], _angular_material_badge__WEBPACK_IMPORTED_MODULE_9__["MatBadgeModule"]]
      });
    })();
    /*@__PURE__*/


    (function () {
      _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](NgMaterialModule, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"],
        args: [{
          imports: [_angular_material_input__WEBPACK_IMPORTED_MODULE_1__["MatInputModule"], _angular_material_table__WEBPACK_IMPORTED_MODULE_2__["MatTableModule"], _angular_material_icon__WEBPACK_IMPORTED_MODULE_3__["MatIconModule"], _angular_material_button__WEBPACK_IMPORTED_MODULE_4__["MatButtonModule"], _angular_material_button_toggle__WEBPACK_IMPORTED_MODULE_5__["MatButtonToggleModule"], _angular_material_tabs__WEBPACK_IMPORTED_MODULE_6__["MatTabsModule"], _angular_material_card__WEBPACK_IMPORTED_MODULE_7__["MatCardModule"], _angular_material_divider__WEBPACK_IMPORTED_MODULE_8__["MatDividerModule"], _angular_material_badge__WEBPACK_IMPORTED_MODULE_9__["MatBadgeModule"]],
          exports: [// CommonModule,
          _angular_material_input__WEBPACK_IMPORTED_MODULE_1__["MatInputModule"], _angular_material_table__WEBPACK_IMPORTED_MODULE_2__["MatTableModule"], _angular_material_icon__WEBPACK_IMPORTED_MODULE_3__["MatIconModule"], _angular_material_button__WEBPACK_IMPORTED_MODULE_4__["MatButtonModule"], _angular_material_button_toggle__WEBPACK_IMPORTED_MODULE_5__["MatButtonToggleModule"], _angular_material_tabs__WEBPACK_IMPORTED_MODULE_6__["MatTabsModule"], _angular_material_card__WEBPACK_IMPORTED_MODULE_7__["MatCardModule"], _angular_material_divider__WEBPACK_IMPORTED_MODULE_8__["MatDividerModule"], _angular_material_badge__WEBPACK_IMPORTED_MODULE_9__["MatBadgeModule"]]
        }]
      }], null, null);
    })();
    /***/

  },

  /***/
  "./src/app/pipes/linkify-pipe.ts":
  /*!***************************************!*\
    !*** ./src/app/pipes/linkify-pipe.ts ***!
    \***************************************/

  /*! exports provided: LinkifyPipe */

  /***/
  function srcAppPipesLinkifyPipeTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "LinkifyPipe", function () {
      return LinkifyPipe;
    });
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
    /* harmony import */


    var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/platform-browser */
    "./node_modules/@angular/platform-browser/__ivy_ngcc__/fesm2015/platform-browser.js");

    var LinkifyPipe = /*#__PURE__*/function () {
      function LinkifyPipe(domSanitizer) {
        _classCallCheck(this, LinkifyPipe);

        this.domSanitizer = domSanitizer;
      }

      _createClass(LinkifyPipe, [{
        key: "transform",
        value: function transform(value) {
          var result = value.replace(/[\$|@|\#][(\^)a-zA-Z]+/g, function (match) {
            var linkParam = match.replace(/[\$|@|\#]/g, "");
            var linkIndicator = match[0];

            switch (linkIndicator) {
              case '$':
                return "<a href=\"/stock/".concat(linkParam, "\">").concat(match, "</a>");

              case '@':
                return "<a href=\"/user/".concat(linkParam, "\">").concat(match, "</a>");

              case '#':
                return "<a href=\"/tag/".concat(linkParam, "\">").concat(match, "</a>");
            }
          });
          return this.domSanitizer.bypassSecurityTrustHtml(result);
        }
      }]);

      return LinkifyPipe;
    }();

    LinkifyPipe.ɵfac = function LinkifyPipe_Factory(t) {
      return new (t || LinkifyPipe)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdirectiveInject"](_angular_platform_browser__WEBPACK_IMPORTED_MODULE_1__["DomSanitizer"]));
    };

    LinkifyPipe.ɵpipe = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefinePipe"]({
      name: "linkify",
      type: LinkifyPipe,
      pure: true
    });
    /*@__PURE__*/

    (function () {
      _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](LinkifyPipe, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Pipe"],
        args: [{
          name: "linkify"
        }]
      }], function () {
        return [{
          type: _angular_platform_browser__WEBPACK_IMPORTED_MODULE_1__["DomSanitizer"]
        }];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/app/pipes/stirp-html-pipe.ts":
  /*!******************************************!*\
    !*** ./src/app/pipes/stirp-html-pipe.ts ***!
    \******************************************/

  /*! exports provided: StripHtmlPipe */

  /***/
  function srcAppPipesStirpHtmlPipeTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "StripHtmlPipe", function () {
      return StripHtmlPipe;
    });
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var StripHtmlPipe = /*#__PURE__*/function () {
      function StripHtmlPipe() {
        _classCallCheck(this, StripHtmlPipe);
      }

      _createClass(StripHtmlPipe, [{
        key: "transform",
        value: function transform(value) {
          return value.replace(/(<([^>]+)>|&#\d+;)/ig, "");
        }
      }]);

      return StripHtmlPipe;
    }();

    StripHtmlPipe.ɵfac = function StripHtmlPipe_Factory(t) {
      return new (t || StripHtmlPipe)();
    };

    StripHtmlPipe.ɵpipe = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefinePipe"]({
      name: "striphtml",
      type: StripHtmlPipe,
      pure: true
    });
    /*@__PURE__*/

    (function () {
      _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](StripHtmlPipe, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Pipe"],
        args: [{
          name: 'striphtml'
        }]
      }], null, null);
    })();
    /***/

  },

  /***/
  "./src/app/post-details/post-details.component.ts":
  /*!********************************************************!*\
    !*** ./src/app/post-details/post-details.component.ts ***!
    \********************************************************/

  /*! exports provided: PostDetailsComponent */

  /***/
  function srcAppPostDetailsPostDetailsComponentTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "PostDetailsComponent", function () {
      return PostDetailsComponent;
    });
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var PostDetailsComponent = /*#__PURE__*/function () {
      function PostDetailsComponent() {
        _classCallCheck(this, PostDetailsComponent);
      }

      _createClass(PostDetailsComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {}
      }]);

      return PostDetailsComponent;
    }();

    PostDetailsComponent.ɵfac = function PostDetailsComponent_Factory(t) {
      return new (t || PostDetailsComponent)();
    };

    PostDetailsComponent.ɵcmp = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineComponent"]({
      type: PostDetailsComponent,
      selectors: [["app-post-details"]],
      decls: 2,
      vars: 0,
      template: function PostDetailsComponent_Template(rf, ctx) {
        if (rf & 1) {
          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "p");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1, "post-details works!");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        }
      },
      styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL3Bvc3QtZGV0YWlscy9wb3N0LWRldGFpbHMuY29tcG9uZW50LmNzcyJ9 */"]
    });
    /*@__PURE__*/

    (function () {
      _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](PostDetailsComponent, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"],
        args: [{
          selector: 'app-post-details',
          templateUrl: './post-details.component.html',
          styleUrls: ['./post-details.component.css']
        }]
      }], function () {
        return [];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/app/stock/stock.component.ts":
  /*!******************************************!*\
    !*** ./src/app/stock/stock.component.ts ***!
    \******************************************/

  /*! exports provided: StockComponent */

  /***/
  function srcAppStockStockComponentTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "StockComponent", function () {
      return StockComponent;
    });
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var StockComponent = /*#__PURE__*/function () {
      function StockComponent() {
        _classCallCheck(this, StockComponent);
      }

      _createClass(StockComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {}
      }]);

      return StockComponent;
    }();

    StockComponent.ɵfac = function StockComponent_Factory(t) {
      return new (t || StockComponent)();
    };

    StockComponent.ɵcmp = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineComponent"]({
      type: StockComponent,
      selectors: [["app-stock"]],
      decls: 2,
      vars: 0,
      template: function StockComponent_Template(rf, ctx) {
        if (rf & 1) {
          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "p");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1, "stock works!");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        }
      },
      styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL3N0b2NrL3N0b2NrLmNvbXBvbmVudC5jc3MifQ== */"]
    });
    /*@__PURE__*/

    (function () {
      _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](StockComponent, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"],
        args: [{
          selector: 'app-stock',
          templateUrl: './stock.component.html',
          styleUrls: ['./stock.component.css']
        }]
      }], function () {
        return [];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/app/submit-post-form/submit-post-form.component.ts":
  /*!****************************************************************!*\
    !*** ./src/app/submit-post-form/submit-post-form.component.ts ***!
    \****************************************************************/

  /*! exports provided: SubmitPostFormComponent */

  /***/
  function srcAppSubmitPostFormSubmitPostFormComponentTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "SubmitPostFormComponent", function () {
      return SubmitPostFormComponent;
    });
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
    /* harmony import */


    var _angular_material_card__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/material/card */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/card.js");
    /* harmony import */


    var _angular_material_form_field__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! @angular/material/form-field */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/form-field.js");
    /* harmony import */


    var _angular_material_input__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
    /*! @angular/material/input */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/input.js");
    /* harmony import */


    var _angular_material_button__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(
    /*! @angular/material/button */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/button.js");

    var SubmitPostFormComponent = /*#__PURE__*/function () {
      function SubmitPostFormComponent() {
        _classCallCheck(this, SubmitPostFormComponent);

        // bullBearIndicator: number;
        this.isBearish = false;
      }

      _createClass(SubmitPostFormComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {}
      }, {
        key: "submit",
        value: function submit() {// console.log(this.bullBearIndicator);
        }
      }, {
        key: "bearishClick",
        value: function bearishClick() {
          this.isBearish = !this.isBearish;
          this.isBullish = false;
          console.log(this.isBearish);
        }
      }, {
        key: "bullishClick",
        value: function bullishClick() {
          this.isBullish = !this.isBullish;
          this.isBearish = false;
        }
      }]);

      return SubmitPostFormComponent;
    }();

    SubmitPostFormComponent.ɵfac = function SubmitPostFormComponent_Factory(t) {
      return new (t || SubmitPostFormComponent)();
    };

    SubmitPostFormComponent.ɵcmp = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineComponent"]({
      type: SubmitPostFormComponent,
      selectors: [["app-submit-post-form"]],
      decls: 16,
      vars: 4,
      consts: [[1, "tiririt-form"], [1, "form-field"], ["matInput", "", "placeholder", "Ex. @supertrader @bulltactics $GLO did very well last quarter. #panalo", "maxlength", "300"], [1, "post-action-container"], [1, "post-bear-bull"], ["mat-stroked-button", "", "color", "basic", 3, "click"], [1, "post-buttons"], ["mat-raised-button", "", "color", "primary", 3, "click"]],
      template: function SubmitPostFormComponent_Template(rf, ctx) {
        if (rf & 1) {
          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "mat-card");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](1, "mat-card-content");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](2, "form", 0);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](3, "mat-form-field", 1);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](4, "mat-label");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](5, "Say something about your favorite stock");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](6, "textarea", 2);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](7, "div", 3);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](8, "div", 4);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](9, "button", 5);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵlistener"]("click", function SubmitPostFormComponent_Template_button_click_9_listener() {
            return ctx.bearishClick();
          });

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](10, " Bearish");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](11, "button", 5);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵlistener"]("click", function SubmitPostFormComponent_Template_button_click_11_listener() {
            return ctx.bullishClick();
          });

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](12, " Bullish");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](13, "div", 6);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](14, "button", 7);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵlistener"]("click", function SubmitPostFormComponent_Template_button_click_14_listener() {
            return ctx.submit();
          });

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](15, "Post");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        }

        if (rf & 2) {
          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](9);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵclassProp"]("isBearish", ctx.isBearish);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](2);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵclassProp"]("isBullish", ctx.isBullish);
        }
      },
      directives: [_angular_material_card__WEBPACK_IMPORTED_MODULE_1__["MatCard"], _angular_material_card__WEBPACK_IMPORTED_MODULE_1__["MatCardContent"], _angular_material_form_field__WEBPACK_IMPORTED_MODULE_2__["MatFormField"], _angular_material_form_field__WEBPACK_IMPORTED_MODULE_2__["MatLabel"], _angular_material_input__WEBPACK_IMPORTED_MODULE_3__["MatInput"], _angular_material_button__WEBPACK_IMPORTED_MODULE_4__["MatButton"]],
      styles: [".tiririt-form[_ngcontent-%COMP%] {\r\n    width: 100%;\r\n}\r\n\r\n.form-field[_ngcontent-%COMP%] {\r\n    width: 100%;\r\n}\r\n\r\n.post-action-container[_ngcontent-%COMP%] {\r\n    display: flex;\r\n}\r\n\r\n.post-bear-bull[_ngcontent-%COMP%] {\r\n    width: 70%;\r\n}\r\n\r\n.post-buttons[_ngcontent-%COMP%] {\r\n    width: 30%;\r\n    text-align: right;\r\n}\r\n\r\n.isBearish[_ngcontent-%COMP%] {\r\n    background-color: red;\r\n    color: white;\r\n}\r\n\r\n.isBullish[_ngcontent-%COMP%] {\r\n    background-color: green;\r\n    color: white;\r\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvc3VibWl0LXBvc3QtZm9ybS9zdWJtaXQtcG9zdC1mb3JtLmNvbXBvbmVudC5jc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7SUFDSSxXQUFXO0FBQ2Y7O0FBRUE7SUFDSSxXQUFXO0FBQ2Y7O0FBRUE7SUFDSSxhQUFhO0FBQ2pCOztBQUVBO0lBQ0ksVUFBVTtBQUNkOztBQUVBO0lBQ0ksVUFBVTtJQUNWLGlCQUFpQjtBQUNyQjs7QUFFQTtJQUNJLHFCQUFxQjtJQUNyQixZQUFZO0FBQ2hCOztBQUVBO0lBQ0ksdUJBQXVCO0lBQ3ZCLFlBQVk7QUFDaEIiLCJmaWxlIjoic3JjL2FwcC9zdWJtaXQtcG9zdC1mb3JtL3N1Ym1pdC1wb3N0LWZvcm0uY29tcG9uZW50LmNzcyIsInNvdXJjZXNDb250ZW50IjpbIi50aXJpcml0LWZvcm0ge1xyXG4gICAgd2lkdGg6IDEwMCU7XHJcbn1cclxuXHJcbi5mb3JtLWZpZWxkIHtcclxuICAgIHdpZHRoOiAxMDAlO1xyXG59XHJcblxyXG4ucG9zdC1hY3Rpb24tY29udGFpbmVyIHtcclxuICAgIGRpc3BsYXk6IGZsZXg7XHJcbn1cclxuXHJcbi5wb3N0LWJlYXItYnVsbCB7XHJcbiAgICB3aWR0aDogNzAlO1xyXG59XHJcblxyXG4ucG9zdC1idXR0b25zIHtcclxuICAgIHdpZHRoOiAzMCU7XHJcbiAgICB0ZXh0LWFsaWduOiByaWdodDtcclxufVxyXG5cclxuLmlzQmVhcmlzaCB7XHJcbiAgICBiYWNrZ3JvdW5kLWNvbG9yOiByZWQ7XHJcbiAgICBjb2xvcjogd2hpdGU7XHJcbn1cclxuXHJcbi5pc0J1bGxpc2gge1xyXG4gICAgYmFja2dyb3VuZC1jb2xvcjogZ3JlZW47XHJcbiAgICBjb2xvcjogd2hpdGU7XHJcbn1cclxuXHJcblxyXG4iXX0= */"]
    });
    /*@__PURE__*/

    (function () {
      _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](SubmitPostFormComponent, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"],
        args: [{
          selector: 'app-submit-post-form',
          templateUrl: './submit-post-form.component.html',
          styleUrls: ['./submit-post-form.component.css']
        }]
      }], function () {
        return [];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/app/tag/tag.component.ts":
  /*!**************************************!*\
    !*** ./src/app/tag/tag.component.ts ***!
    \**************************************/

  /*! exports provided: TagComponent */

  /***/
  function srcAppTagTagComponentTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "TagComponent", function () {
      return TagComponent;
    });
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var TagComponent = /*#__PURE__*/function () {
      function TagComponent() {
        _classCallCheck(this, TagComponent);
      }

      _createClass(TagComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {}
      }]);

      return TagComponent;
    }();

    TagComponent.ɵfac = function TagComponent_Factory(t) {
      return new (t || TagComponent)();
    };

    TagComponent.ɵcmp = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineComponent"]({
      type: TagComponent,
      selectors: [["app-tag"]],
      decls: 2,
      vars: 0,
      template: function TagComponent_Template(rf, ctx) {
        if (rf & 1) {
          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "p");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1, "tag works!");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        }
      },
      styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL3RhZy90YWcuY29tcG9uZW50LmNzcyJ9 */"]
    });
    /*@__PURE__*/

    (function () {
      _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](TagComponent, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"],
        args: [{
          selector: 'app-tag',
          templateUrl: './tag.component.html',
          styleUrls: ['./tag.component.css']
        }]
      }], function () {
        return [];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/app/user/user.component.ts":
  /*!****************************************!*\
    !*** ./src/app/user/user.component.ts ***!
    \****************************************/

  /*! exports provided: UserComponent */

  /***/
  function srcAppUserUserComponentTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "UserComponent", function () {
      return UserComponent;
    });
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var UserComponent = /*#__PURE__*/function () {
      function UserComponent() {
        _classCallCheck(this, UserComponent);
      }

      _createClass(UserComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {}
      }]);

      return UserComponent;
    }();

    UserComponent.ɵfac = function UserComponent_Factory(t) {
      return new (t || UserComponent)();
    };

    UserComponent.ɵcmp = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineComponent"]({
      type: UserComponent,
      selectors: [["app-user"]],
      decls: 2,
      vars: 0,
      template: function UserComponent_Template(rf, ctx) {
        if (rf & 1) {
          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "p");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1, "user works!");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        }
      },
      styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL3VzZXIvdXNlci5jb21wb25lbnQuY3NzIn0= */"]
    });
    /*@__PURE__*/

    (function () {
      _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](UserComponent, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"],
        args: [{
          selector: 'app-user',
          templateUrl: './user.component.html',
          styleUrls: ['./user.component.css']
        }]
      }], function () {
        return [];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/app/watchlist/watchlist.component.ts":
  /*!**************************************************!*\
    !*** ./src/app/watchlist/watchlist.component.ts ***!
    \**************************************************/

  /*! exports provided: WatchlistComponent */

  /***/
  function srcAppWatchlistWatchlistComponentTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "WatchlistComponent", function () {
      return WatchlistComponent;
    });
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
    /* harmony import */


    var _angular_material_table__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/material/table */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/table.js");
    /* harmony import */


    var _watchlist_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! ./watchlist.service */
    "./src/app/watchlist/watchlist.service.ts");
    /* harmony import */


    var _angular_material_form_field__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
    /*! @angular/material/form-field */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/form-field.js");
    /* harmony import */


    var _angular_material_input__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(
    /*! @angular/material/input */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/input.js");
    /* harmony import */


    var _angular_material_button__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(
    /*! @angular/material/button */
    "./node_modules/@angular/material/__ivy_ngcc__/fesm2015/button.js");

    function WatchlistComponent_th_6_Template(rf, ctx) {
      if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "th", 9);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1, "Symbol");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
      }
    }

    function WatchlistComponent_td_7_Template(rf, ctx) {
      if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "td", 10);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
      }

      if (rf & 2) {
        var stock_r6 = ctx.$implicit;

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtextInterpolate1"](" ", stock_r6.symbol, " ");
      }
    }

    function WatchlistComponent_th_9_Template(rf, ctx) {
      if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "th", 9);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1, "Last Price");

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
      }
    }

    function WatchlistComponent_td_10_Template(rf, ctx) {
      if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "td", 10);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
      }

      if (rf & 2) {
        var stock_r7 = ctx.$implicit;

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);

        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtextInterpolate"](stock_r7.symbol);
      }
    }

    function WatchlistComponent_tr_11_Template(rf, ctx) {
      if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](0, "tr", 11);
      }
    }

    function WatchlistComponent_tr_12_Template(rf, ctx) {
      if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](0, "tr", 12);
      }
    }

    var WatchlistComponent = /*#__PURE__*/function () {
      function WatchlistComponent(watchListService) {
        _classCallCheck(this, WatchlistComponent);

        this.watchListService = watchListService;
        this.dataSource = new _angular_material_table__WEBPACK_IMPORTED_MODULE_1__["MatTableDataSource"]();
        this.displayedColumns = ['symbol', 'price'];
      }

      _createClass(WatchlistComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {
          var _this8 = this;

          this.watchListService.getWatchList().subscribe(function (result) {
            _this8.dataSource = new _angular_material_table__WEBPACK_IMPORTED_MODULE_1__["MatTableDataSource"](result.stocks);
            console.log(result);
          }, function (error) {
            return console.error(error);
          });
        }
      }]);

      return WatchlistComponent;
    }();

    WatchlistComponent.ɵfac = function WatchlistComponent_Factory(t) {
      return new (t || WatchlistComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdirectiveInject"](_watchlist_service__WEBPACK_IMPORTED_MODULE_2__["WatchlistService"]));
    };

    WatchlistComponent.ɵcmp = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineComponent"]({
      type: WatchlistComponent,
      selectors: [["app-watchlist"]],
      decls: 13,
      vars: 3,
      consts: [["matInput", "", "placeholder", "Enter symbol"], ["mat-raised-button", "", "color", "primary"], ["mat-table", "", 1, "mat-elevation-z8", 3, "dataSource"], ["matColumnDef", "symbol"], ["mat-header-cell", "", 4, "matHeaderCellDef"], ["mat-cell", "", 4, "matCellDef"], ["matColumnDef", "price"], ["mat-header-row", "", 4, "matHeaderRowDef"], ["mat-row", "", 4, "matRowDef", "matRowDefColumns"], ["mat-header-cell", ""], ["mat-cell", ""], ["mat-header-row", ""], ["mat-row", ""]],
      template: function WatchlistComponent_Template(rf, ctx) {
        if (rf & 1) {
          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "mat-form-field");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](1, "input", 0);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](2, "button", 1);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](3, "Add");

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](4, "table", 2);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementContainerStart"](5, 3);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](6, WatchlistComponent_th_6_Template, 2, 0, "th", 4);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](7, WatchlistComponent_td_7_Template, 2, 1, "td", 5);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementContainerEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementContainerStart"](8, 6);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](9, WatchlistComponent_th_9_Template, 2, 0, "th", 4);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](10, WatchlistComponent_td_10_Template, 2, 1, "td", 5);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementContainerEnd"]();

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](11, WatchlistComponent_tr_11_Template, 1, 0, "tr", 7);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](12, WatchlistComponent_tr_12_Template, 1, 0, "tr", 8);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        }

        if (rf & 2) {
          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](4);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("dataSource", ctx.dataSource);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](7);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("matHeaderRowDef", ctx.displayedColumns);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);

          _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("matRowDefColumns", ctx.displayedColumns);
        }
      },
      directives: [_angular_material_form_field__WEBPACK_IMPORTED_MODULE_3__["MatFormField"], _angular_material_input__WEBPACK_IMPORTED_MODULE_4__["MatInput"], _angular_material_button__WEBPACK_IMPORTED_MODULE_5__["MatButton"], _angular_material_table__WEBPACK_IMPORTED_MODULE_1__["MatTable"], _angular_material_table__WEBPACK_IMPORTED_MODULE_1__["MatColumnDef"], _angular_material_table__WEBPACK_IMPORTED_MODULE_1__["MatHeaderCellDef"], _angular_material_table__WEBPACK_IMPORTED_MODULE_1__["MatCellDef"], _angular_material_table__WEBPACK_IMPORTED_MODULE_1__["MatHeaderRowDef"], _angular_material_table__WEBPACK_IMPORTED_MODULE_1__["MatRowDef"], _angular_material_table__WEBPACK_IMPORTED_MODULE_1__["MatHeaderCell"], _angular_material_table__WEBPACK_IMPORTED_MODULE_1__["MatCell"], _angular_material_table__WEBPACK_IMPORTED_MODULE_1__["MatHeaderRow"], _angular_material_table__WEBPACK_IMPORTED_MODULE_1__["MatRow"]],
      styles: [".watchlist-container[_ngcontent-%COMP%] {\r\n    margin: 5px;\r\n    width: 100%;\r\n}\r\n\r\n.toolbar[_ngcontent-%COMP%] {\r\n    width: 100%;\r\n}\r\n\r\n.mat-form-field[_ngcontent-%COMP%] {\r\n    width: 100px;\r\n    margin-right: 5px;\r\n}\r\n\r\ntable[_ngcontent-%COMP%] {\r\n    width: 100%;\r\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvd2F0Y2hsaXN0L3dhdGNobGlzdC5jb21wb25lbnQuY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0lBQ0ksV0FBVztJQUNYLFdBQVc7QUFDZjs7QUFFQTtJQUNJLFdBQVc7QUFDZjs7QUFFQTtJQUNJLFlBQVk7SUFDWixpQkFBaUI7QUFDckI7O0FBRUE7SUFDSSxXQUFXO0FBQ2YiLCJmaWxlIjoic3JjL2FwcC93YXRjaGxpc3Qvd2F0Y2hsaXN0LmNvbXBvbmVudC5jc3MiLCJzb3VyY2VzQ29udGVudCI6WyIud2F0Y2hsaXN0LWNvbnRhaW5lciB7XHJcbiAgICBtYXJnaW46IDVweDtcclxuICAgIHdpZHRoOiAxMDAlO1xyXG59XHJcblxyXG4udG9vbGJhciB7XHJcbiAgICB3aWR0aDogMTAwJTtcclxufVxyXG5cclxuLm1hdC1mb3JtLWZpZWxkIHtcclxuICAgIHdpZHRoOiAxMDBweDtcclxuICAgIG1hcmdpbi1yaWdodDogNXB4O1xyXG59XHJcblxyXG50YWJsZSB7XHJcbiAgICB3aWR0aDogMTAwJTtcclxufSJdfQ== */"]
    });
    /*@__PURE__*/

    (function () {
      _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](WatchlistComponent, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"],
        args: [{
          selector: 'app-watchlist',
          templateUrl: './watchlist.component.html',
          styleUrls: ['./watchlist.component.css']
        }]
      }], function () {
        return [{
          type: _watchlist_service__WEBPACK_IMPORTED_MODULE_2__["WatchlistService"]
        }];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/app/watchlist/watchlist.service.ts":
  /*!************************************************!*\
    !*** ./src/app/watchlist/watchlist.service.ts ***!
    \************************************************/

  /*! exports provided: WatchlistService */

  /***/
  function srcAppWatchlistWatchlistServiceTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "WatchlistService", function () {
      return WatchlistService;
    });
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
    /* harmony import */


    var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/common/http */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/http.js");

    var WatchlistService = /*#__PURE__*/function () {
      function WatchlistService(http, baseUrl) {
        _classCallCheck(this, WatchlistService);

        this.http = http;
        this.baseUrl = baseUrl;
      }

      _createClass(WatchlistService, [{
        key: "getWatchList",
        value: function getWatchList() {
          var url = 'https://localhost:44303/api/v1/WatchList';
          return this.http.get(url);
        }
      }]);

      return WatchlistService;
    }();

    WatchlistService.ɵfac = function WatchlistService_Factory(t) {
      return new (t || WatchlistService)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"](_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"]('BASE_URL'));
    };

    WatchlistService.ɵprov = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineInjectable"]({
      token: WatchlistService,
      factory: WatchlistService.ɵfac,
      providedIn: 'root'
    });
    /*@__PURE__*/

    (function () {
      _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](WatchlistService, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"],
        args: [{
          providedIn: 'root'
        }]
      }], function () {
        return [{
          type: _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]
        }, {
          type: undefined,
          decorators: [{
            type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Inject"],
            args: ['BASE_URL']
          }]
        }];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/environments/environment.ts":
  /*!*****************************************!*\
    !*** ./src/environments/environment.ts ***!
    \*****************************************/

  /*! exports provided: environment */

  /***/
  function srcEnvironmentsEnvironmentTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "environment", function () {
      return environment;
    }); // This file can be replaced during build by using the `fileReplacements` array.
    // `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
    // The list of file replacements can be found in `angular.json`.


    var environment = {
      production: false
    };
    /*
     * For easier debugging in development mode, you can import the following file
     * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
     *
     * This import should be commented out in production mode because it will have a negative impact
     * on performance if an error is thrown.
     */
    // import 'zone.js/dist/zone-error';  // Included with Angular CLI.

    /***/
  },

  /***/
  "./src/main.ts":
  /*!*********************!*\
    !*** ./src/main.ts ***!
    \*********************/

  /*! exports provided: getBaseUrl */

  /***/
  function srcMainTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "getBaseUrl", function () {
      return getBaseUrl;
    });
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
    /* harmony import */


    var _environments_environment__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! ./environments/environment */
    "./src/environments/environment.ts");
    /* harmony import */


    var _app_app_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! ./app/app.module */
    "./src/app/app.module.ts");
    /* harmony import */


    var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
    /*! @angular/platform-browser */
    "./node_modules/@angular/platform-browser/__ivy_ngcc__/fesm2015/platform-browser.js");

    function getBaseUrl() {
      return document.getElementsByTagName('base')[0].href;
    }

    var providers = [{
      provide: 'BASE_URL',
      useFactory: getBaseUrl,
      deps: []
    }];

    if (_environments_environment__WEBPACK_IMPORTED_MODULE_1__["environment"].production) {
      Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["enableProdMode"])();
    }

    _angular_platform_browser__WEBPACK_IMPORTED_MODULE_3__["platformBrowser"](providers).bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_2__["AppModule"])["catch"](function (err) {
      return console.error(err);
    });
    /***/

  },

  /***/
  0:
  /*!***************************!*\
    !*** multi ./src/main.ts ***!
    \***************************/

  /*! no static exports found */

  /***/
  function _(module, exports, __webpack_require__) {
    module.exports = __webpack_require__(
    /*! D:\Projects\tiririt\Client\src\main.ts */
    "./src/main.ts");
    /***/
  }
}, [[0, "runtime", "vendor"]]]);
//# sourceMappingURL=main-es5.js.map