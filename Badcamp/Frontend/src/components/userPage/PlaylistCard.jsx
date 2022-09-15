import Card from 'react-bootstrap/Card';
import ListGroup from 'react-bootstrap/ListGroup';

const PlaylistCard = ({ user }) => {
    return (
        <div>
            <Card.Body>
                <Card.Title>Playlist</Card.Title>
                <Card.Text>{user.playlist}</Card.Text>
            </Card.Body>
            <ListGroup className="list-group-flush" >
                <ListGroup.Item></ListGroup.Item>
                <ListGroup.Item></ListGroup.Item>
                <ListGroup.Item></ListGroup.Item>
                <ListGroup.Item></ListGroup.Item>
                <ListGroup.Item></ListGroup.Item>
                <ListGroup.Item></ListGroup.Item>
                <ListGroup.Item></ListGroup.Item>
            </ListGroup>
        </div>
    );
}

export default PlaylistCard;