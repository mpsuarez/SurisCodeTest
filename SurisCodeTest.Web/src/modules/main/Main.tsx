import { useState, useEffect, useCallback } from "react";
import { Outlet } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { toggleSidebarMenu } from "@app/store/reducers/ui";
import { addWindowClass, removeWindowClass, sleep } from "@app/utils/helpers";
import ControlSidebar from "@app/modules/main/control-sidebar/ControlSidebar";
import Header from "@app/modules/main/header/Header";
import MenuSidebar from "@app/modules/main/menu-sidebar/MenuSidebar";
import Footer from "@app/modules/main/footer/Footer";

const Main = () => {
    const dispatch = useDispatch();
    const menuSidebarCollapsed = useSelector(
        (state: any) => state.ui.menuSidebarCollapsed
    );
    const controlSidebarCollapsed = useSelector(
        (state: any) => state.ui.controlSidebarCollapsed
    );
    const screenSize = useSelector((state: any) => state.ui.screenSize);

    const handleToggleMenuSidebar = () => {
        dispatch(toggleSidebarMenu());
    };

    useEffect(() => {
        removeWindowClass("register-page");
        removeWindowClass("login-page");
        removeWindowClass("hold-transition");

        addWindowClass("sidebar-mini");

        // fetchProfile();
        return () => {
            removeWindowClass("sidebar-mini");
        };
    }, []);

    useEffect(() => {
        removeWindowClass("sidebar-closed");
        removeWindowClass("sidebar-collapse");
        removeWindowClass("sidebar-open");
        if (menuSidebarCollapsed && screenSize === "lg") {
            addWindowClass("sidebar-collapse");
        } else if (menuSidebarCollapsed && screenSize === "xs") {
            addWindowClass("sidebar-open");
        } else if (!menuSidebarCollapsed && screenSize !== "lg") {
            addWindowClass("sidebar-closed");
            addWindowClass("sidebar-collapse");
        }
    }, [screenSize, menuSidebarCollapsed]);

    useEffect(() => {
        if (controlSidebarCollapsed) {
            removeWindowClass("control-sidebar-slide-open");
        } else {
            addWindowClass("control-sidebar-slide-open");
        }
    }, [screenSize, controlSidebarCollapsed]);

    return (
        <div className="wrapper">
            <Header />
            <MenuSidebar />
            <div className="content-wrapper">
                <div className="pt-3" />
                <section className="content">
                    <Outlet />
                </section>
            </div>
            <Footer />
            <ControlSidebar />
            <div
                id="sidebar-overlay"
                role="presentation"
                onClick={handleToggleMenuSidebar}
                onKeyDown={() => {}}
            />
        </div>
    );
};

export default Main;
