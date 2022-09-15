import React from 'react'
import FilterInput from './FilterInput'
import SearchInput from './SearchInput'
import { InputGroup } from 'react-bootstrap'

const InputContainer = ({searchValue,setSearchValue, filterValue, setFilterValue, genres}) => {

  return (
    <section>
    <InputGroup className="mb-2 w-50" style={{margin : "auto"}}>
        <SearchInput
            searchValue={searchValue}
            setSearchValue={setSearchValue}
        />
        <FilterInput
            filterValue={filterValue}
            setFilterValue={setFilterValue}
            genres={genres}
        />
        </InputGroup>
    </section>
  )
}

export default InputContainer