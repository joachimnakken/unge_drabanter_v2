/** @type {import('next').NextConfig} */
const nextConfig = {
  reactStrictMode: true,
  images: {
    // images: {
    //   domains: ["unsplash.com"],
    // },

    remotePatterns: [
      {
        protocol: "https",
        hostname: "images.unsplash.com",
        pathname: "/photo-**",
        port: "",
      },
    ],
  },
};

module.exports = nextConfig;
