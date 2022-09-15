import React from 'react'

const ItemList = (props) => {
  return (
    <ul>
        {props.items.map((item) => <li>{item}</li>)}
    </ul>
  )
}

export default ItemList;