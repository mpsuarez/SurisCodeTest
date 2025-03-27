import react from "@vitejs/plugin-react";
import { defineConfig } from "vite";
import path from "path";
import mkcert from "vite-plugin-mkcert";

export default defineConfig((configEnv) => {
    const isDevelopment = configEnv.mode === "development";
    return {
        plugins: [react(), mkcert()],
        resolve: {
            alias: {
                "@app": path.resolve(__dirname, "./src"),
                "@store": path.resolve(__dirname, "./src/store"),
                "@components": path.resolve(__dirname, "./src/components"),
                "@modules": path.resolve(__dirname, "./src/modules"),
                "@pages": path.resolve(__dirname, "./src/pages"),
            },
        },
        css: {
            modules: {
                generateScopedName: isDevelopment
                    ? "[name]__[local]__[hash:base64:5]"
                    : "[hash:base64:5]",
            },
        },
    };
});
