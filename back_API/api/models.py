from django.db import models

# Create your models here.
class Sexo(models.Model):
    SEXO_CHOICES = (
        ("F", "Feminino"),
        ("M", "Masculino"),
        ("N", "Nenhuma das opções")
    )
    sexo = models.CharField(max_length=1, choices=SEXO_CHOICES, blank=False, null=False)
    
    def __str__(self):
        return self.sexo

class Cliente(models.Model):
    nome = models.CharField(max_length=100, null=False, blank=False)
    sexo = models.ForeignKey("Sexo", on_delete=models.CASCADE)
    email = models.EmailField(null=False, blank=False)
    data_nascimento = models.DateField(null=False, blank=False)
    
    def __str__(self):
        return self.nome
    
class Produto(models.Model):
    nome = models.CharField(max_length=50, null=False, blank=False)
    valor = models.FloatField(null=False, blank=False)
    unidade= models.CharField(max_length=50, null=False, blank=False)

    def __str__(self):
        return self.nome
    
class Ingresso(models.Model):
    nome = models.CharField(max_length=50, null=False, blank=False)
    descricao= models.CharField(max_length=258, null=False, blank=False)
    valor = models.FloatField(null=False, blank=False)
    
    def __str__(self):
        return self.nome

class ConsumoCliente(models.Model):
    cliente = models.ForeignKey("Cliente", on_delete=models.CASCADE, related_name='pedidos')
    produtos = models.ManyToManyField(Produto)
    
class IngressoCliente(models.Model):
    cliente = models.ForeignKey("Cliente", on_delete=models.CASCADE, related_name='clientes')
    ingresso = models.ForeignKey("Ingresso", on_delete=models.CASCADE, related_name='ingressos')

# class ProdutoConsumo(models.Model):
#     produto = models.ForeignKey("Produto", on_delete=models.CASCADE)
#     consumo = models.ForeignKey("ConsumoCliente", on_delete=models.CASCADE)
#     qtd = models.PositiveIntegerField()