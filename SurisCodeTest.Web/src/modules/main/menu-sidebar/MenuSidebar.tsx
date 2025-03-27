import { useSelector } from "react-redux";
import { Link } from "react-router-dom";
import { MenuItem } from "@components";
import { Image } from "@profabric/react-components";
import styled from "styled-components";
import i18n from "@app/utils/i18n";

export interface IMenuItem {
    name: string;
    icon?: string;
    path?: string;
    children?: Array<IMenuItem>;
}

export const MENU: IMenuItem[] = [
    {
        name: "Reservar",
        icon: "far fa-sticky-note",
        path: "/Reserve",
    },
    {
        name: "Lista de Reservas",
        icon: "fas fa-list",
        path: "/ReserveList",
    },
];

const StyledBrandImage = styled(Image)`
    float: left;
    line-height: 0.8;
    margin: -1px 8px 0 6px;
    opacity: 0.8;
    --pf-box-shadow: 0 10px 20px rgba(0, 0, 0, 0.19),
        0 6px 6px rgba(0, 0, 0, 0.23) !important;
`;

const StyledUserImage = styled(Image)`
    --pf-box-shadow: 0 3px 6px #00000029, 0 3px 6px #0000003b !important;
`;

const MenuSidebar = () => {
    const sidebarSkin = useSelector((state: any) => state.ui.sidebarSkin);
    const menuItemFlat = useSelector((state: any) => state.ui.menuItemFlat);
    const menuChildIndent = useSelector(
        (state: any) => state.ui.menuChildIndent
    );

    return (
        <aside className={`main-sidebar elevation-4 ${sidebarSkin}`}>
            <Link to="/" className="brand-link text-center">
                <span className="brand-text font-weight-light">
                    TacticalSoft Test
                </span>
            </Link>
            <div className="sidebar">
                <nav className="mt-2" style={{ overflowY: "hidden" }}>
                    <ul
                        className={`nav nav-pills nav-sidebar flex-column${
                            menuItemFlat ? " nav-flat" : ""
                        }${menuChildIndent ? " nav-child-indent" : ""}`}
                        role="menu"
                    >
                        {MENU.map((menuItem: IMenuItem) => (
                            <MenuItem
                                key={menuItem.name + menuItem.path}
                                menuItem={menuItem}
                            />
                        ))}
                    </ul>
                </nav>
            </div>
        </aside>
    );
};

export default MenuSidebar;
