import React from 'react'
import { Dropdown, DropdownButton } from 'react-bootstrap'

const FilterInput = ({filterValue,setFilterValue,genres}) => {
    const handleSelect = (e) =>{
        setFilterValue(e)
    }

  return (
    <DropdownButton
    title={!filterValue ? "Genres" : filterValue}
    id="dropdown-menu-align-right"
    onSelect={(e) => handleSelect(e)}
    className='m-0'
      >
        {genres.map((genre, index) =>(
            <Dropdown.Item key={index} eventKey={genre}>{genre}</Dropdown.Item>
        ))}
        <Dropdown.Item eventKey=''>none</Dropdown.Item>

    </DropdownButton>
  )
}

export default FilterInput