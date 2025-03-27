/// <reference types="vite/client" />
/// <reference types="vite-plugin-comlink/client" />


interface ImportMetaEnv {
    readonly VITE_INTERIDENTITY_WEBAPICLIENT_URL: string
    // más variables de entorno...
  }
  
  interface ImportMeta {
    readonly env: ImportMetaEnv
  }