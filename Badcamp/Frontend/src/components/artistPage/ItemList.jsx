import React from 'react'

const ItemList = (listProps) => {
  return (
    <ul>
        {listProps.items.map((item) => <li>{item}</li>)}
    </ul>
  )
}

export default ItemList;