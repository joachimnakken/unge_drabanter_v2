import "../styles/globals.css";
import type { AppProps } from "next/app";

export default function App({ Component, pageProps }: AppProps) {
  return (
    <>
      <div className="min-h-screen p-4">
        <Component {...pageProps} />
      </div>
    </>
  );
}
