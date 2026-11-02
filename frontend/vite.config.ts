import { fileURLToPath, URL } from 'node:url'
import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

export default defineConfig({
  plugins: [vue()],
  resolve: {
    alias: { '@': fileURLToPath(new URL('./src', import.meta.url)) },
  },
  server: {
    // Redirige /api al backend: el navegador ve un solo origen y la cookie funciona sin CORS
    proxy: { '/api': { target: 'http://localhost:5000', changeOrigin: true } },
  },
})