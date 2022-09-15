import React from 'react'

const ItemList = ({listData}) => {
  return (
    <ul>
        {listData.map((item, index) => <li key={index}>{item.id}</li>)}
    </ul>
  )
}

export default ItemList;