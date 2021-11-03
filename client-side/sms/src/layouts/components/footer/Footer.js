import React from "react"
import ScrollToTop from "react-scroll-up"
import { Button } from "reactstrap"
import { ArrowUp } from "react-feather"
import classnames from "classnames"

const Footer = () => {
  return (
    <footer className={classnames("footer footer-light", "static")}>
      <p className="mb-0 clearfix">
        <span className="float-md-left d-block d-md-inline-block mt-25">
         All rights reserved - COPYRIGHT © {new Date().getFullYear()}
          <a
            href="demo.com"
            target="_blank"
            rel="noopener noreferrer"
          >
            Z-Desk,
          </a>
        </span>
        <span className="float-md-right d-none d-md-block">
          <span className="align-middle">Powered by </span>{" "}
          <a href="www.encodersit.com">Encoders IT</a>
        </span>
      </p>
      <ScrollToTop showUnder={160}>*/}
        <Button color="primary" className="btn-icon scroll-top">
          <ArrowUp size={15} />
        </Button>
      </ScrollToTop>
    </footer>
  )
}

export default Footer
