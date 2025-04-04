import { useCallback } from "react";
import { Link } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { useDispatch, useSelector } from "react-redux";
import {
    toggleControlSidebar,
    toggleSidebarMenu,
} from "@app/store/reducers/ui";

const Header = () => {
    const [t] = useTranslation();
    const dispatch = useDispatch();
    const navbarVariant = useSelector((state: any) => state.ui.navbarVariant);
    const headerBorder = useSelector((state: any) => state.ui.headerBorder);

    const handleToggleMenuSidebar = () => {
        dispatch(toggleSidebarMenu());
    };

    const handleToggleControlSidebar = () => {
        dispatch(toggleControlSidebar());
    };

    const getContainerClasses = useCallback(() => {
        let classes = `main-header navbar navbar-expand ${navbarVariant}`;
        if (headerBorder) {
            classes = `${classes} border-bottom-0`;
        }
        return classes;
    }, [navbarVariant, headerBorder]);

    return (
        <nav className={getContainerClasses()}>
            <ul className="navbar-nav">
                <li className="nav-item">
                    <button
                        onClick={handleToggleMenuSidebar}
                        type="button"
                        className="nav-link"
                    >
                        <i className="fas fa-bars" />
                    </button>
                </li>
            </ul>
        </nav>
    );
};

export default Header;
