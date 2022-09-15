import Card from 'react-bootstrap/Card';
import ListGroup from 'react-bootstrap/ListGroup';

const CardItem = ({ user }) => {
    return (
        <div>
            <Card.Body>
                <Card.Title>{user.username}</Card.Title>
            </Card.Body>
            <ListGroup className="list-group-flush">
                <ListGroup.Item variant="light">Full name: {user.fullName}</ListGroup.Item>
                <ListGroup.Item variant="light">Date of birth: {user.dateOfBirth}</ListGroup.Item>
            </ListGroup>
            <Card.Body>
                <Card.Link href="#">Edit info</Card.Link>
            </Card.Body>
        </div>
    );
}

export default CardItem;