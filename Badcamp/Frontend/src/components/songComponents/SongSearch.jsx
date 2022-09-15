import React from 'react'
import { InputGroup, Form } from 'react-bootstrap'

const SearchInput = ({ searchValue, setSearchValue }) => {
    const cardWidth = { maxWidth: "30%" }
    return (
        <InputGroup className="mb-2 " style={cardWidth}>
            <Form.Control onSubmit={(e) => e.preventDefault()}
                placeholder="Search songs"
                aria-label="Username"
                value={searchValue}
                onChange={(e) => {
                    console.log(searchValue)
                    setSearchValue(e.target.value)
                }}
            />
        </InputGroup>
    )
}

export default SearchInput