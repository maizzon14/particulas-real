He creado un sistema de partículas en 3D personalizable siguiendo las pautas dadas en el PDF.

El usuario puede cambiar en el inspector la velocidad inicial, el angulo, el tiempo de vida maximo de cada particula y la gravedad.
También aparece la información del tiempo que lleva activa la partícula.

Después he creado un manager para las partículas con el que puedes gestionar la cantidad de partículas que quieres que salgan al principio.
El método para crear partículas se repite la cantidad de veces que el usuario le indique, creando así esa misma cantidad de partículas.

Cada partícula tiene un angulo inicial, velocidad y tiempo de vida aleatorios al nacer. Su gravedad se mantiene igual para todas.

Luego cree un metodo para actualizar la posición de cada partícula, siguiendo la fórmula cinemática del tiro parabólico.


El generador de partículas se crea en el Start(), siento que es más simple de ver y es más accesible. Sin embargo para hacerlo con la tecla tendría que hacer esto:

if(Input.GetKeyDown(KeyCode.E)) 
{
	CreateParticleExplosion(15);

}
Después en el proyecto de Unity tendría que activar ambos Input System, el nuevo tanto como el antiguo para que esa línea de código funcionase, podría hacerlo también con el nuevo Input System pero me parece más simple así.

Las partículas se destruyen cuando su tiempo activas superan su tiempo de vida máximo dado aleatoriamente al nacer.
Cada vez que una partícula se destruye se genera una partícula nueva, llamando de nuevo al método de crear partículas y pasándole cuantás quieres crear en su parámetro. CreateParticleExplosion(1);