import React from "react";

const SkipToMainContentLink = () => {
  return (
    <a
      href="#main"
      className="fixed z-10 px-4 py-2 text-sm font-bold text-white transition-all duration-300 bg-black rounded opacity-0 bottom-4 -left-96 focus:bottom-4 focus:left-4 focus:opacity-100"
    >
      Skip to main content
    </a>
  );
};

export default SkipToMainContentLink;
