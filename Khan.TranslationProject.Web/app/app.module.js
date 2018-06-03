"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var platform_browser_1 = require("@angular/platform-browser");
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var animations_1 = require("@angular/platform-browser/animations");
var router_1 = require("@angular/router");
var app_component_1 = require("./app.component");
var user_service_1 = require("./shared/user.service");
var http_1 = require("@angular/common/http");
//import { ToastrModule } from 'ngx-toastr';
var user_component_1 = require("./user/user.component");
var sign_in_component_1 = require("./user/sign-in/sign-in.component");
var home_component_1 = require("./home/home.component");
var sign_up_component_1 = require("./user/sign-up/sign-up.component");
var routes_1 = require("./routes");
var auth_guard_1 = require("./auth/auth.guard");
var auth_interceptor_1 = require("./auth/auth.interceptor");
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        core_1.NgModule({
            declarations: [
                app_component_1.AppComponent,
                sign_up_component_1.SignUpComponent,
                user_component_1.UserComponent,
                sign_in_component_1.SignInComponent,
                home_component_1.HomeComponent
            ],
            imports: [
                platform_browser_1.BrowserModule,
                forms_1.FormsModule,
                http_1.HttpClientModule,
                //ToastrModule.forRoot(),
                animations_1.BrowserAnimationsModule,
                router_1.RouterModule.forRoot(routes_1.appRoutes)
            ],
            providers: [user_service_1.UserService, auth_guard_1.AuthGuard,
                ,
                {
                    provide: http_1.HTTP_INTERCEPTORS,
                    useClass: auth_interceptor_1.AuthInterceptor,
                    multi: true
                }],
            bootstrap: [app_component_1.AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map