import Link from "next/link";

export default function Home() {
  return (
    <main className="">
      <h1>Unge Drabanter</h1>
      <Link href="/login">Login</Link>
    </main>
  );
}
