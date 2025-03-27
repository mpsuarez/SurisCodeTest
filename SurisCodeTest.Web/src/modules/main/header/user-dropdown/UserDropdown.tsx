import { useState } from "react";
import { useNavigate, Link } from "react-router-dom";
import { useSelector } from "react-redux";
import { useTranslation } from "react-i18next";
import { StyledBigUserImage, StyledSmallUserImage } from "@app/styles/common";
import {
    UserBody,
    UserFooter,
    UserHeader,
    UserMenuDropdown,
} from "@app/styles/dropdown-menus";

declare const FB: any;

const UserDropdown = () => {
    const navigate = useNavigate();
    const [t] = useTranslation();
    const [dropdownOpen, setDropdownOpen] = useState(false);

    const navigateToProfile = (event: any) => {
        event.preventDefault();
        setDropdownOpen(false);
        navigate("/profile");
    };

    return (
        <UserMenuDropdown isOpen={dropdownOpen} hideArrow>
            <StyledSmallUserImage
                slot="head"
                src="/img/default-profile.png"
                fallbackSrc="/img/default-profile.png"
                alt="User"
                width={25}
                height={25}
                rounded
            />
            <div slot="body">
                <UserHeader className=" bg-primary">
                    <StyledBigUserImage
                        src="/img/default-profile.png"
                        fallbackSrc="/img/default-profile.png"
                        alt="User"
                        width={90}
                        height={90}
                        rounded
                    />
                    <p>
                        Miguel Peña
                        <small>
                            <span>Member since </span>
                            <span>{"11 de septiembre de 2021"}</span>
                        </small>
                    </p>
                </UserHeader>
                <UserBody>
                    <div className="row">
                        <div className="col-4 text-center">
                            <Link to="/">{t("header.user.followers")}</Link>
                        </div>
                        <div className="col-4 text-center">
                            <Link to="/">{t("header.user.sales")}</Link>
                        </div>
                        <div className="col-4 text-center">
                            <Link to="/">{t("header.user.friends")}</Link>
                        </div>
                    </div>
                </UserBody>
                <UserFooter>
                    <button
                        type="button"
                        className="btn btn-default btn-flat"
                        onClick={navigateToProfile}
                    >
                        {t("header.user.profile")}
                    </button>
                    <button
                        type="button"
                        className="btn btn-default btn-flat float-right"
                    >
                        {t("login.button.signOut")}
                    </button>
                </UserFooter>
            </div>
        </UserMenuDropdown>
    );
};

export default UserDropdown;
