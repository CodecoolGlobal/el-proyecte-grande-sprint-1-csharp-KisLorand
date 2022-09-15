import React from "react";
import { Form } from "react-bootstrap";

const SearchInput = ({ searchValue, setSearchValue }) => {
  return (
    <Form.Control
      onSubmit={(e) => e.preventDefault()}
      placeholder="Search artist"
      aria-label="Username"
      value={searchValue}
      onChange={(e) => {
        setSearchValue(e.target.value);
      }}
    />
  );
};

export default SearchInput;
