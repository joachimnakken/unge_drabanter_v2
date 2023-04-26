import Header from "components/molecules/Header";
import Footer from "components/organisms/Footer";
import { Html, Head, Main, NextScript } from "next/document";

export default function Document() {
  return (
    <Html lang="en">
      <Head />
      <Header />
      <body>
        <Main />
        <NextScript />
      </body>
      <Footer />
    </Html>
  );
}
