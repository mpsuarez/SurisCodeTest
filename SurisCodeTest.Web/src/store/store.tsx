import { configureStore } from "@reduxjs/toolkit";
import { loadUser } from "redux-oidc";
import { uiSlice } from "@app/store/reducers/ui";

import { createLogger } from "redux-logger";

const store = configureStore({
    reducer: {
        ui: uiSlice.reducer,
    },
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware({
            serializableCheck: false,
        }).concat(createLogger()) as any,
});

export default store;
