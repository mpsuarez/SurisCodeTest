import { useTranslation } from "react-i18next";
import { DateTime } from "luxon";
import packageJSON from "../../../../package.json";

const Footer = () => {
    const [t] = useTranslation();

    return (
        <footer className="main-footer">
            <strong>
                <span>Copyright © {DateTime.now().toFormat("y")} </span>
                TacticaSoft Test
                <span>.</span>
            </strong>
            <div className="float-right d-none d-sm-inline-block">
                <b>{t("footer.version")}</b>
                <span>&nbsp;{packageJSON.version}</span>
            </div>
        </footer>
    );
};

export default Footer;
