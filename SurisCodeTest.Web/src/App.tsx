import { useEffect } from "react";
import { Routes, Route } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import { useWindowSize } from "@app/hooks/useWindowSize";
import { calculateWindowSize } from "@app/utils/helpers";
import { useDispatch, useSelector } from "react-redux";
import { setWindowSize } from "@app/store/reducers/ui";
import Main from "@modules/main/Main";
import { processSilentRenew } from "redux-oidc";
import Dashboard from "@pages/Dashboard";
import Reserve from "@pages/Reserve";
import ReserveList from "@pages/ReserveList";

const App = () => {
    const windowSize = useWindowSize();
    const screenSize = useSelector((state: any) => state.ui.screenSize);
    const dispatch = useDispatch();

    useEffect(() => {
        const size = calculateWindowSize(windowSize.width);
        if (screenSize !== size) {
            dispatch(setWindowSize(size));
        }
    }, [windowSize]);

    if (window.location.pathname === "/SilentRenew") {
        return processSilentRenew();
    } else {
        return (
            <>
                <Routes>
                    <Route path="/" element={<Main />}>
                        <Route path="/" element={<Dashboard />} />
                        <Route path="/Reserve" element={<Reserve />} />
                        <Route path="/ReserveList" element={<ReserveList />} />
                    </Route>
                </Routes>
                <ToastContainer
                    autoClose={3000}
                    draggable={false}
                    position="top-right"
                    hideProgressBar={false}
                    newestOnTop
                    closeOnClick
                    rtl={false}
                    pauseOnHover
                />
            </>
        );
    }
};

export default App;
