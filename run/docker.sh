build1="${1:-no}"
build=$(echo "$build1" | tr '[:upper:]' '[:lower:]')
echo "should rebuild? : $build"
function remove_images {
    echo "removing the images"
    DOCKER_IMAGE_TO_REMOVE=$(docker images --filter=reference="dockerfiles*:*" -q)
    docker rmi $DOCKER_IMAGE_TO_REMOVE || (
        echo "Image $DOCKER_IMAGE_TO_REMOVE didn't exist so not removed."
        exit 0
    )
}

function rebuild_images {
    echo "rebuilding the images"
    cd devops/Dockerfiles/
    docker-compose build
}
(cd devops/Dockerfiles/ && docker-compose down)
([[ $build == 'build' ]] && remove_images && rebuild_images)
(cd devops/Dockerfiles/ && docker-compose up)
