const Footer = () => {
  return (
    <footer className="p-10 text-white bg-black">
      <h2>Unge Drabanter 🥃</h2>
      <p>Velkommen til Unge Drabanter - en hjemmeside for unge drabanter.</p>
      <ul>
        <li>
          <a href="/login">Login</a>
        </li>
        <li>
          <a href="/register">Signup</a>
        </li>
      </ul>
      <p>© 2021 Unge Drabanter</p>
      <hr />
      <div>
        <h3>We are using the following technologies:</h3>
        <ul>
          <li>Next.js</li>
          <li>Typescript</li>
          <li>Tailwind CSS</li>
          <li>React Query</li>
        </ul>
      </div>
    </footer>
  );
};

export default Footer;
