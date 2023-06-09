import SkipToMainContentLink from "components/atoms/SkipToMainContentLink";
import Link from "next/link";

const Header = () => {
  return (
    <header>
      <SkipToMainContentLink />
      <nav className="relative flex items-center justify-between h-10 p-6 bg-blue-300">
        <Link href="/" className="flex items-center gap-2">
          <svg
            xmlns="http://www.w3.org/2000/svg"
            fill="none"
            width={40}
            height={40}
            viewBox="0 0 70 70"
          >
            <path
              fill="#000"
              d="M33.381 23h10.017v30.605c0 3.436-.825 6.443-2.476 9.02-1.634 2.578-3.924 4.587-6.87 6.03-2.946 1.426-6.377 2.14-10.294 2.14-3.933 0-7.372-.714-10.318-2.14-2.945-1.443-5.235-3.452-6.87-6.03-1.635-2.577-2.452-5.584-2.452-9.02V23h10.016v29.754c0 1.795.394 3.39 1.18 4.786.802 1.396 1.928 2.493 3.378 3.29 1.45.798 3.138 1.197 5.066 1.197 1.943 0 3.632-.399 5.066-1.196 1.45-.798 2.568-1.895 3.354-3.291.802-1.396 1.203-2.991 1.203-4.786V23Z"
            />
            <path
              fill="#000"
              d="M48.055 70.127H31.261V23h16.933c4.765 0 8.868.943 12.307 2.83 3.439 1.872 6.084 4.564 7.934 8.077 1.867 3.513 2.8 7.717 2.8 12.61 0 4.91-.933 9.128-2.8 12.657-1.85 3.528-4.51 6.236-7.98 8.123-3.455 1.887-7.588 2.83-12.4 2.83Zm-6.778-8.537h6.362c2.96 0 5.451-.522 7.472-1.565 2.036-1.058 3.562-2.692 4.58-4.901 1.033-2.225 1.55-5.093 1.55-8.606 0-3.483-.517-6.328-1.55-8.538-1.018-2.209-2.537-3.835-4.557-4.878-2.02-1.043-4.511-1.565-7.472-1.565h-6.385V61.59ZM47.688 1.313H29.311c-.8 0-1.41.705-1.3 1.497l2.297 14.622a2.624 2.624 0 0 0 2.6 2.251h11.198c1.304 0 2.416-.96 2.6-2.251l2.28-14.622c.111-.792-.5-1.498-1.3-1.498Zm-1.535 2.625-1.23 7.874H32.085l-1.239-7.874h15.308Z"
            />
          </svg>
          Unge Drabanter
        </Link>
        <ul className="flex gap-4">
          <li>
            <Link href="/login">Login</Link>
          </li>
          <li>
            <Link href="/register">Register</Link>
          </li>
          <li>
            <Link href="/app">App</Link>
          </li>
          <li>
            <Link href="/app/events">Events</Link>
          </li>
          <li>
            <Link href="/app/events/event/1">Event</Link>
          </li>
          <li>
            <Link href="/app/events/create">Create Event</Link>
          </li>
          <li>
            <Link href="/app/items">Items</Link>
          </li>
          <li>
            <Link href="/app/items/item/1">Item 1</Link>
          </li>
        </ul>
      </nav>
    </header>
  );
};

export default Header;
