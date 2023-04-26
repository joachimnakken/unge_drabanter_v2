import SkipToMainContentLink from "components/atoms/SkipToMainContentLink";
import Link from "next/link";

const Header = () => {
  return (
    <header>
      <SkipToMainContentLink />
      <nav className="relative flex items-center justify-between h-10 p-4 bg-blue-300">
        <Link href="/" className="flex items-center gap-2">
          <div className="flex w-4 h-4 gap-2">
            <svg
              width="100%"
              height="100%"
              viewBox="0 0 100 100"
              preserveAspectRatio="none"
            >
              <polygon fill="#000" points="0,100 100,0 100,100" />
            </svg>
          </div>
          Unge Drabanter
        </Link>
        <ul className="flex gap-4">
          <li>
            <Link href="/login">Login</Link>
          </li>
          <li>
            <Link href="/register">Register</Link>
          </li>
        </ul>
      </nav>
    </header>
  );
};

export default Header;
