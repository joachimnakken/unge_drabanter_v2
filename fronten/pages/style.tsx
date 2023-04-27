export default function Style() {
  return (
    <main className="p-4">
      <h1>Style page:</h1>
      <p>This page is for testing styles.</p>
      <hr />
      <h2>Colors:</h2>
      <section className="grid grid-cols-12 gap-4 py-4 text-center">
        <div className="flex items-center justify-center aspect-square bg-primary text-on-primary">
          <p>primary</p>
        </div>
        <div className="container flex items-center justify-center aspect-square bg-primary-container text-on-primary-container">
          <p>primary container</p>
        </div>

        <div className="flex items-center justify-center aspect-square bg-secondary text-on-secondary">
          <p>secondary</p>
        </div>
        <div className="container flex items-center justify-center aspect-square bg-secondary-container text-on-secondary-container">
          <p>secondary container</p>
        </div>

        <div className="flex items-center justify-center aspect-square bg-tertiary text-on-tertiary">
          <p>tertiary</p>
        </div>

        <div className="flex items-center justify-center aspect-square bg-tertiary-container text-primary">
          <p>tertiary container</p>
        </div>
        <div className="container flex items-center justify-center aspect-square bg-surface text-on-surface">
          <p>surface</p>
        </div>
        <div className="container flex items-center justify-center aspect-square bg-surface-dim">
          <p>surface dim</p>
        </div>
        <div className="container flex items-center justify-center aspect-square bg-surface-dim">
          <p>surface bright</p>
        </div>
        <div className="container flex items-center justify-center aspect-square bg-surface-container-lowest">
          <p>surface container lowest</p>
        </div>
        <div className="container flex items-center justify-center aspect-square bg-surface-container-low">
          <p>surface container lowe</p>
        </div>
        <div className="container flex items-center justify-center aspect-square bg-surface-container">
          <p>surface container</p>
        </div>
        <div className="container flex items-center justify-center aspect-square bg-surface-container-high">
          <p>surface container high</p>
        </div>
        <div className="container flex items-center justify-center aspect-square bg-surface-container-highest">
          <p>surface container highest</p>
        </div>
        <div className="container flex items-center justify-center aspect-square bg-surface-variant text-on-surface-variant">
          <p>surface variant</p>
        </div>
        <div className="container flex items-center justify-center aspect-square bg-inverse-surface text-inverse-on-surface">
          <p>surface inverse</p>
        </div>
        <div className="container flex items-center justify-center aspect-square bg-background text-on-background">
          <p>background</p>
        </div>
        <div className="container flex items-center justify-center aspect-square bg-error text-on-error">
          <p>error</p>
        </div>
        <div className="container flex items-center justify-center aspect-square bg-error-container text-on-error-container">
          <p>error container</p>
        </div>
        <div className="container flex items-center justify-center aspect-square bg-outline">
          <p>Outline</p>
        </div>
        <div className="container flex items-center justify-center aspect-square bg-outline-variant">
          <p>Outline variant</p>
        </div>
        <div className="container flex items-center justify-center bg-shadow aspect-square text-on-primary">
          <p>shadow</p>
        </div>
        <div className="container flex items-center justify-center bg-surface-tint aspect-square text-on-primary">
          <p>surface tint</p>
        </div>
        <div className="container flex items-center justify-center bg-scrim aspect-square text-on-primary">
          <p>scrim</p>
        </div>

        {/*  */}
      </section>
      <hr />
      <section className="">
        <h1>H1</h1>
        <h2>H2</h2>
        <h3>H3</h3>
        <h4>H4</h4>
        <h5>H5</h5>
        <h6>H6</h6>
        <p className="text-6xl">Text 6xl</p>
        <p className="text-5xl">Text 5xl</p>
        <p className="text-4xl">Text 4xl</p>
        <p className="text-3xl">Text 3xl</p>
        <p className="text-2xl">Text 2xl</p>
        <p className="text-xl">Text xl</p>
        <p className="text-lg">Text lg</p>
        <p>Paragraph</p>
        <p className="text-sm">Text sm</p>
        <p className="text-xs">Text xs</p>
        <div>
          <small>Small</small>
        </div>
        <div>
          <strong>Strong</strong>
        </div>
        <div>
          <b>Bold</b>
        </div>
        <div>
          <em>Emphasis</em>
        </div>
        <div>
          <i>Italic</i>
        </div>
        <div>
          <u>Underline</u>
        </div>
        <div>
          <del>Deleted</del>
        </div>
        <div>
          <ins>Inserted</ins>
        </div>
        <div>
          <code>Code</code>
        </div>
        <pre>Pre</pre>
        <blockquote>Blockquote</blockquote>
        <q>Quote</q>
        <abbr>Abbr</abbr>
        <address>Address</address>
        <div>
          <cite>Cite</cite>
        </div>
        <div>
          <dfn>Definition</dfn>
        </div>
        <div>
          <kbd>Keyboard</kbd>
        </div>
        <div>
          <samp>Sample</samp>
        </div>
        <div>
          <var>Variable</var>
        </div>
        <div>
          <sup>Superscript</sup>
        </div>
        <div>
          <sub>Subscript</sub>
        </div>
        <div>
          <time>Time</time>
        </div>
        <div>
          <a href="#">Link</a>
        </div>
      </section>
    </main>
  );
}
